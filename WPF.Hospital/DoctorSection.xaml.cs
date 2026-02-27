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
    /// Interaction logic for DoctorSection.xaml
    /// </summary>
    public partial class DoctorSection : Window
    {
        private readonly IDoctorService _doctorService;

        public DoctorSection(IDoctorService doctorService)
        {
            InitializeComponent();
            _doctorService = doctorService;

            DataContext = new DoctorViewModel();
        }

        private void btnAddDoctor_Click(object sender, RoutedEventArgs e)
        {
            var vm = (DoctorViewModel)DataContext;

            var result = _doctorService.Create(new DTO.Doctor()
            {
                FirstName = vm.FirstName,
                LastName = vm.LastName
            });

            MessageBox.Show(result.Message);
        }
    }
}
