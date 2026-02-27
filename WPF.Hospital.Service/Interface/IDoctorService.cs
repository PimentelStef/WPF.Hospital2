using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Hospital.DTO;

namespace WPF.Hospital.Service
{
    public interface IDoctorService
    {
        IEnumerable<Doctor> GetAll();
        (bool ok, string Message) Create(Doctor doctor);
        (bool ok, string Message) Delete(int id);
    }
}