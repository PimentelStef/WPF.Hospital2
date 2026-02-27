using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Hospital.ViewModel
{
    public class PrescriptionViewModel
    {
        public int Id { get; set; }
        public string Dosage { get; set; }
        public string Frequency { get; set; }
    }
}
