using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Hospital.Model;

namespace WPF.Hospital.Repository
{
    public interface IPrescriptionRepository : IRepository<Prescription>
    {
        Prescription Get(int id);
        IEnumerable<Prescription> GetAll();
        IEnumerable<Prescription> GetByHistoryId(int historyId);
    }
}
