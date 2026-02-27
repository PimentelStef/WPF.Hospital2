using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Hospital.DTO;
using WPF.Hospital.Repository;
using WPF.Hospital.Service;

namespace WPF.Hospital.Service
{
    public class MedicineService : IMedicineService
    {
        private readonly IMedicineRepository _medicineRepository;

        public MedicineService(IMedicineRepository medicineRepository)
        {
            _medicineRepository = medicineRepository;
        }

        public Medicine Get(int id)
        {
            var medicine = _medicineRepository.Get(id);

            return new Medicine
            {
                Id = medicine.Id,
                Name = medicine.Name,
                Brand = medicine.Brand
            };
        }

        public IEnumerable<Medicine> GetAll()
        {
            return _medicineRepository.GetAll()
                .Select(m => new Medicine
                {
                    Id = m.Id,
                    Name = m.Name,
                    Brand = m.Brand
                });
        }

        public void Add(Medicine medicine)
        {
            _medicineRepository.Add(new Model.Medicine
            {
                Name = medicine.Name,
                Brand = medicine.Brand
            });

            _medicineRepository.Save();
        }

        public void Delete(int id)
        {
            _medicineRepository.Delete(id);
            _medicineRepository.Save();
        }
    }
}
