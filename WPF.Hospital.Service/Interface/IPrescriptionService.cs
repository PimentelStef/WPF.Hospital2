using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Hospital.DTO;

namespace WPF.Hospital.Service
{
    public interface IPrescriptionService
    {
        IEnumerable<Prescription> GetByHistoryId(int historyId);
        (bool ok, string Message) Create(Prescription prescription);
        void Delete(int id);
    }
}
