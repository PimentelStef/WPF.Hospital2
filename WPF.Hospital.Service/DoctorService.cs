using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Hospital.DTO;
using WPF.Hospital.Repository;

namespace WPF.Hospital.Service
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IHistoryRepository _historyRepository;

        public DoctorService(
            IDoctorRepository doctorRepository,
            IHistoryRepository historyRepository)
        {
            _doctorRepository = doctorRepository;
            _historyRepository = historyRepository;
        }

        public IEnumerable<Doctor> GetAll()
        {
            return _doctorRepository.GetAll()
                .Select(d => new Doctor
                {
                    Id = d.Id,
                    FirstName = d.FirstName,
                    LastName = d.LastName
                });
        }

        public (bool ok, string Message) Create(Doctor doctor)
        {
            if (string.IsNullOrWhiteSpace(doctor.FirstName) ||
                string.IsNullOrWhiteSpace(doctor.LastName))
                return (false, "Doctor name required");

            var exists = _doctorRepository.GetAll()
                .Any(d => d.FirstName == doctor.FirstName &&
                          d.LastName == doctor.LastName);

            if (exists)
                return (false, "Doctor already exists");

            _doctorRepository.Add(new Model.Doctor
            {
                FirstName = doctor.FirstName,
                LastName = doctor.LastName
            });

            _doctorRepository.Save();

            return (true, "Doctor added");
        }

        public void Delete(int id)
        {
            var used = _historyRepository.GetAll()
                .Any(h => h.DoctorId == id);

            if (used)
                throw new Exception("Doctor is used in history");

            _doctorRepository.Delete(id);
            _doctorRepository.Save();
        }
    }
}
