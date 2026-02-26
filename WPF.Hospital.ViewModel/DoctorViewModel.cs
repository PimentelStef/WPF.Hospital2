using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Hospital.ViewModel
{
    public class DoctorViewModel
    {
        public ObservableCollection<Doctor> Doctors { get; set; } = new();

        public void AddDoctor()
        {
            var result = _service.Create(new Doctor
            {
                FirstName = FirstName,
                LastName = LastName
            });

            MessageBox.Show(result.Message);

            if (result.Ok)
                LoadDoctors();
        }
    }
}
