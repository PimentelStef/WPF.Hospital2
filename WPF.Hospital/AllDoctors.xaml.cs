using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF.Hospital.Service;
using WPF.Hospital.ViewModel;

namespace WPF.Hospital
{
    /// <summary>
    /// Interaction logic for AllDoctors.xaml
    /// </summary>
    public partial class AllDoctors : Window
    {
        private readonly IDoctorService _doctorService;

        public AllDoctors(IDoctorService doctorService)
        {
            InitializeComponent();
            _doctorService = doctorService;

            DataContext = new
            {
                Doctors = _doctorService.GetAll()
                    .Select(d => new DoctorViewModel()
                    {
                        Id = d.Id,
                        FirstName = d.FirstName,
                        LastName = d.LastName
                    })
            };
        }
    }
}
