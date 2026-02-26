using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Hospital.DTO;

namespace WPF.Hospital.Service
{
    public interface IMedicineService
    {
        Medicine Get(int id);
        IEnumerable<Medicine> GetAll();
        void Add(Medicine medicine);
        void Delete(int id);
    }
}