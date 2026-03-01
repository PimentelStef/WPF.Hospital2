using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Hospital.DTO;
using WPF.Hospital.Repository;

namespace WPF.Hospital.Service
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IPrescriptionRepository _repo;
        private readonly IMedicineRepository _medicineRepository;

        public PrescriptionService(
            IPrescriptionRepository repo,
            IMedicineRepository medicineRepository)
        {
            _repo = repo;
            _medicineRepository = medicineRepository;
        }

        public IEnumerable<Prescription> GetByHistoryId(int historyId)
        {
            return _repo.GetByHistoryId(historyId)
                .Select(p => new Prescription
                {
                    Id = p.Id,
                    HistoryId = p.HistoryId,
                    MedicineId = p.MedicineId,
                    Quantity = p.Quantity,
                    Frequency = p.Frequency
                });
        }

        public (bool ok, string Message) Create(Prescription p)
        {
            if (p.HistoryId <= 0)
            {
                return (false, "History required");
            }

            if (p.MedicineId <= 0)
            {
                return (false, "Medicine required");
            }

            if (p.Quantity <= 0)
            {
                return (false, "Quantity must be greater than 0");
            }

            if (string.IsNullOrWhiteSpace(p.Frequency))
            {
                return (false, "Frequency required");
            }

            var exists = _medicineRepository.Get(p.MedicineId);
            if (exists == null)
            {
                return (false, "Medicine does not exist");
            }

            var duplicate = _repo.GetByHistoryId(p.HistoryId)
                .Any(x => x.MedicineId == p.MedicineId);

            if (duplicate)
            {
                return (false, "Duplicate medicine");
            }

            _repo.Add(new Model.Prescription
            {
                HistoryId = p.HistoryId,
                MedicineId = p.MedicineId,
                Quantity = p.Quantity,
                Frequency = p.Frequency
            });

            _repo.Save();

            return (true, "Prescription added");
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
            _repo.Save();
        }
    }
}
