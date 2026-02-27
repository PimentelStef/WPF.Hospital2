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
    /// Interaction logic for DeletePrescription.xaml
    /// </summary>
    public partial class DeletePrescription : Window
    {
        private readonly IPrescriptionService _prescriptionService;

        public DeletePrescription(IPrescriptionService prescriptionService)
        {
            InitializeComponent();
            _prescriptionService = prescriptionService;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtPrescriptionId.Text, out int id))
            {
                MessageBox.Show("Invalid Prescription ID.");
                return;
            }

            bool deleted = _prescriptionService.Delete(id);

            MessageBox.Show(deleted
                ? "Prescription deleted successfully!"
                : "Prescription not found.");

            if (deleted)
                this.Close();
        }
    }
}
