using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Hospital.DTO
{
    public class Prescription
    {
        public int Id { get; set; }

        public History History { get; set; }
        public Medicine Medicine { get; set; }

        public int Quantity { get; set; }
        public string Frequency { get; set; }
    }
}
