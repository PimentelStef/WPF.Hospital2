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
    public partial class PrescriptionSection : Window
    {
        private readonly IPrescriptionService _prescriptionService;
        private readonly IMedicineService _medicineService;

        public PrescriptionSection(IPrescriptionService prescriptionService, IMedicineService medicineService)
        {
            InitializeComponent();
            _prescriptionService = prescriptionService;
            _medicineService = medicineService;
            DataContext = new PrescriptionViewModel
            {
                Medicines = _medicineService.GetAll()
                .Select(m => new MedicineViewModel
                {
                Id = m.Id,
                Name = m.Name,
                Brand = m.Brand
                })
            };
        }

        private void btnAddPrescription_Click(object sender, RoutedEventArgs e)
        {
            var vm = (PrescriptionViewModel)DataContext;

            var result = _prescriptionService.Create(new DTO.Prescription()
            {
                HistoryId = vm.Id,
                MedicineId = vm.SelectedMedicineId,
                Quantity = Convert.ToInt32(vm.Quantity),
                Frequency = vm.Frequency
            });

            MessageBox.Show(result.Message);

            if (result.ok)
                this.DialogResult = true;
        }
    }
}
