using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WPF.Hospital.Service;
using WPF.Hospital.ViewModel;

namespace WPF.Hospital
{
    /// <summary>
    /// Interaction logic for AllPatients.xaml
    /// </summary>
    public partial class AllPatients : Window
    {
        private readonly IPatientService _patientService;

        public AllPatients(IPatientService patientService)
        {
            InitializeComponent();
            _patientService = patientService;
            DataContext = new
            {
                Patients = _patientService.GetAll().Select(p => new PatientViewModel()
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Age = p.Age.ToString(),
                    Birthdate = p.Birthdate
                })
            };
        }
    }
}
