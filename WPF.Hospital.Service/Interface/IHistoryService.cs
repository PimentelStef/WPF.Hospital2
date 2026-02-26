using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Hospital.DTO;

namespace WPF.Hospital.Service
{
    public interface IHistoryService
    {
        History Get(int id);
        IEnumerable<History> GetByPatientId(int patientId);
        (bool ok, string Message) Create(History history);
        void Delete(int id);
    }
}