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

namespace WPF.Hospital
{
    /// <summary>
    /// Interaction logic for DeleteMedicine.xaml
    /// </summary>
    public partial class DeleteMedicine : Window
    {
        private readonly IMedicineService _medicineService;

        public DeleteMedicine(IMedicineService medicineService)
        {
            InitializeComponent();
            _medicineService = medicineService;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtMedicineId.Text, out int id))
            {
                MessageBox.Show("Invalid Medicine ID.");
                return;
            }

            // The Delete method returns void, so we need to check if the medicine exists before deleting
            var medicine = _medicineService.Get(id);
            if (medicine == null)
            {
                MessageBox.Show("Medicine not found.",
                                "Error",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
                return;
            }

            _medicineService.Delete(id);
            MessageBox.Show("Medicine deleted successfully!");
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
