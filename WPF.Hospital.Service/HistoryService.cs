using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Hospital.DTO;
using WPF.Hospital.Repository;

namespace WPF.Hospital.Service
{
    public class HistoryService : IHistoryService
    {
        private readonly IHistoryRepository _historyRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IPrescriptionRepository _prescriptionRepository;

        public HistoryService(
            IHistoryRepository historyRepository,
            IDoctorRepository doctorRepository,
            IPrescriptionRepository prescriptionRepository)
        {
            _historyRepository = historyRepository;
            _doctorRepository = doctorRepository;
            _prescriptionRepository = prescriptionRepository;
        }

        public History Get(int id)
        {
            var history = _historyRepository.Get(id);

            return new History
            {
                Id = history.Id,
                Procedure = history.Procedure,
                PatientId = history.PatientId,
                DoctorId = history.DoctorId
            };
        }

        public IEnumerable<History> GetByPatientId(int patientId)
        {
            return _historyRepository.GetByPatientId(patientId)
                .Select(h => new History
                {
                    Id = h.Id,
                    Procedure = h.Procedure,
                    PatientId = h.PatientId,
                    DoctorId = h.DoctorId
                });
        }

        public (bool ok, string Message) Create(History history)
        {
            if (history.PatientId <= 0)
            {
                return (false, "Patient required");
            }

            if (history.DoctorId <= 0)
            {
                return (false, "Doctor required");
            }

            if (string.IsNullOrWhiteSpace(history.Procedure))
            {
                return (false, "Procedure required");
            }

            var doctorExists = _doctorRepository.Get(history.DoctorId);
            if (doctorExists == null)
            {
                return (false, "Doctor does not exist");
            }

            _historyRepository.Add(new Model.History
            {
                PatientId = history.PatientId,
                DoctorId = history.DoctorId,
                Procedure = history.Procedure
            });

            _historyRepository.Save();

            return (true, "History added");
        }

        public void Delete(int id)
        {
            var hasPrescription = _prescriptionRepository
                .GetByHistoryId(id).Any();

            if (hasPrescription)
                throw new Exception("Cannot delete history with prescriptions");

            _historyRepository.Delete(id);
            _historyRepository.Save();
        }
    }
}
