using System;
using System.Windows;
using WPF.Hospital.Service;

namespace WPF.Hospital
{
    public partial class DeletePatient : Window
    {
        private readonly IPatientService _patientService;

        public DeletePatient(IPatientService patientService)
        {
            InitializeComponent();
            _patientService = patientService;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPatientId.Text))
            {
                MessageBox.Show("Patient ID is required.");
                return;
            }

            int patientId;

            if (!int.TryParse(txtPatientId.Text, out patientId))
            {
                MessageBox.Show("Patient ID must be a number.");
                return;
            }

            _patientService.Delete(patientId);

            MessageBox.Show("Patient deleted successfully!");
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}