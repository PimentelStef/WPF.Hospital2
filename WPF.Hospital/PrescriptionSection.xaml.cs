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
    /// Interaction logic for PrescriptionSection.xaml
    /// </summary>
    public partial class Prescription : Window
    {
        private readonly IPrescriptionService _prescriptionService;

        public Prescription(IPrescriptionService prescriptionService)
        {
            InitializeComponent();
            _prescriptionService = prescriptionService;

            DataContext = new PrescriptionViewModel();
        }

        private void btnAddPrescription_Click(object sender, RoutedEventArgs e)
        {
            var vm = (PrescriptionViewModel)DataContext;

            var result = _prescriptionService.Create(new DTO.Prescription()
            {
                HistoryId = vm.HistoryId,
                MedicineId = vm.MedicineId,
                Quantity = Convert.ToInt32(vm.Quantity),
                Frequency = vm.Frequency
            });

            MessageBox.Show(result.Message);
        }
    }
}
