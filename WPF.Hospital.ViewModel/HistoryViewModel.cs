using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Hospital.ViewModel
{
    public class HistoryViewModel
    {
        public int Id { get; set; }

        public string Procedure { get; set; }

        public int SelectedDoctorId { get; set; }

        public IEnumerable<DoctorViewModel> Doctors { get; set; }
    }
}
