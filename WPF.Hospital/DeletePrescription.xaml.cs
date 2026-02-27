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
            if (string.IsNullOrWhiteSpace(txtPrescriptionId.Text))
            {
                MessageBox.Show("Prescription ID is required.");
                return;
            }

            int historyId;

            if (!int.TryParse(txtPrescriptionId.Text, out historyId))
            {
                MessageBox.Show("History ID must be a number.");
                return;
            }

            _prescriptionService.Delete(historyId);

            MessageBox.Show("History deleted successfully!");
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
