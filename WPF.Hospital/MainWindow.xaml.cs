using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF.Hospital.DTO;
using WPF.Hospital.Service;

namespace WPF.Hospital
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;
        private readonly IMedicineService _medicineService;
        private readonly IHistoryService _HistoryService;
        private readonly IPrescriptionService _prescriptionService;
        public MainWindow(IPatientService patientService, IDoctorService doctorService, IMedicineService medicineService, IHistoryService medicalHistoryService, IPrescriptionService prescriptionService)
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            _patientService = patientService;
            _doctorService = doctorService;
            _medicineService = medicineService;
            _HistoryService = medicalHistoryService;
            _prescriptionService = prescriptionService;
        }

        private void btnAddPatient_Click(object sender, RoutedEventArgs e)
        {
            AddPatient addPatient = new AddPatient(_patientService);
            addPatient.ShowDialog();
        }

        private void btnAllPatients_Click(object sender, RoutedEventArgs e)
        {
            AllPatients allPatients = new AllPatients(_patientService);
            allPatients.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DeletePatient deletePatient = new DeletePatient(_patientService);
            deletePatient.ShowDialog();
        }

        private void btnManageHistory_Click(object sender, RoutedEventArgs e)
        {
            History history = new History();
            history.ShowDialog();
        }

        private void btnAddDoctor_Click(object sender, RoutedEventArgs e)
        {
            AddDoctor addDoctor = new AddDoctor(_doctorService);
            addDoctor.ShowDialog();
        }

        private void btnAllDoctor_Click(object sender, RoutedEventArgs e)
        {
            AllDoctors allDoctors = new AllDoctors(_doctorService);
            allDoctors.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DeleteDoctor deleteDoctor = new DeleteDoctor(_doctorService);
            deleteDoctor.ShowDialog();
        }
        private void btnAddMedicine_Click(object sender, RoutedEventArgs e)
        {
            AddMedicine addMedicine = new AddMedicine(_medicineService);
            addMedicine.ShowDialog();
        }
        private void btnAllMedicines_Click(object sender, RoutedEventArgs e)
        {
            AllMedicines allMedicines = new AllMedicines(_medicineService);
            allMedicines.ShowDialog();
        }
        private void btnDeleteMedicine_Click(object sender, RoutedEventArgs e)
        {
            DeleteMedicine deleteMedicine = new DeleteMedicine(_medicineService);
            deleteMedicine.ShowDialog();
        }
        private void btnAddHistory_Click(object sender, RoutedEventArgs e)
        {
            AddMedicalHistory history = new AddMedicalHistory(_HistoryService);
            history.ShowDialog();
        }
        private void btnAllHistory_Click(object sender, RoutedEventArgs e)
        {
            AllHistory history = new AllHistory(_HistoryService);
            history.ShowDialog();
        }
        private void btnDeleteHistory_Click(object sender, RoutedEventArgs e)
        {
            DeleteMedicalHistory history = new DeleteMedicalHistory(_HistoryService);
            history.ShowDialog();
        }
        private void btnAddPrescription_Click(object sender, RoutedEventArgs e)
        {
            AddPrescription prescription = new AddPrescription(_prescriptionService);
            prescription.ShowDialog();
        }
        private void btnAllPrescriptions_Click(object sender, RoutedEventArgs e)
        {
            AllPrescriptions prescription = new AllPrescriptions(_prescriptionService);
            prescription.ShowDialog();
        }
        private void btnDeletePrescription_Click(object sender, RoutedEventArgs e)
        {
            DeletePrescription prescription = new DeletePrescription(_prescriptionService);
            prescription.ShowDialog();
        }
    }
}