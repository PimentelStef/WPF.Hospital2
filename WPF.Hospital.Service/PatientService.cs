using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using WPF.Hospital.DTO;
using WPF.Hospital.Repository;
using WPF.Hospital.Service;

namespace WPF.Hospital.Service
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IHistoryRepository _historyRepository;

        public PatientService(IPatientRepository patientRepository, IHistoryRepository historyRepository)
        {
            _patientRepository = patientRepository;
            _historyRepository = historyRepository;
        }

        public Patient Get(int id)
        {
            Model.Patient patient = _patientRepository.Get(id);

            return new Patient
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Age = patient.Age,
                Birthdate = patient.Birthdate,
                History = _historyRepository.GetByPatientId(id)
                    .Select(h => new History
                    {
                        Id = h.Id,
                        Procedure = h.Procedure
                    })
            };
        }
        public IEnumerable<Patient> GetAll()
        {
            return _patientRepository.GetAll()
                .Select(patient => new Patient()
                {
                    Id = patient.Id,
                    FirstName = patient.FirstName,
                    LastName = patient.LastName,
                    Age = patient.Age,
                    Birthdate = patient.Birthdate,
                });
        }
        public (bool ok, string Message) Create(Patient patient)
        {
            if (string.IsNullOrEmpty(patient.FirstName))
            {
                return (false, "First name is required.");
            }
            if (string.IsNullOrEmpty(patient.LastName))
            {
                return (false, "Last name is required.");
            }
            if (patient.Age <= 0)
            {
                return (false, "Age must be greater than 0.");
            }
            if (patient.Birthdate > DateTime.Now)
            {
                return (false, "Birthdate cannot be in the future.");
            }

            IEnumerable<Model.Patient> patients = _patientRepository.GetAll();

            if (patients.Any(m => m.FirstName.Contains(patient.FirstName) && m.LastName.Contains(patient.LastName)))
                return (false, "Patient with the same name already exists.");

            _patientRepository.Add(new Model.Patient
                {
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Age = patient.Age,
                Birthdate = patient.Birthdate
            });

            return (true, "Patient created successfully.");
        }


        public void Add(Patient patient)
        {
            _patientRepository.Add(new Model.Patient
            {
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Age = patient.Age,
                Birthdate = patient.Birthdate
            });

            _patientRepository.Save();
        }
        public void Delete(int id)
        {
            _patientRepository.Delete(id);
            _patientRepository.Save();
        }
    }
}