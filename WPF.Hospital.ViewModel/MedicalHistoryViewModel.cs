using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Hospital.ViewModel
{
    public class MedicalHistoryViewModel
    {
        public int Id { get; set; }
        public string Procedure { get; set; }
        public DateTime Date { get; set; }
    }
}
