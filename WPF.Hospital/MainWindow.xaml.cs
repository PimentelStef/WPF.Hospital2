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
        public MainWindow(IPatientService patientService, IDoctorService DoctorService, IMedicineService MedicineService, IHistoryService HistoryService, IPrescriptionService PrescriptionService)
        {
            InitializeComponent();
            this.WindowState = WindowState.Maximized;
            _patientService = patientService;
            _doctorService = DoctorService;
            _medicineService = MedicineService;
            _HistoryService = HistoryService;
            _prescriptionService = PrescriptionService;
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
            HistorySection history = new HistorySection(_HistoryService, _doctorService, _patientService);
            history.ShowDialog();
        }

        private void btnAddDoctor_Click(object sender, RoutedEventArgs e)
        {
            DoctorSection addDoctor = new DoctorSection(_doctorService);
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
            HistorySection history = new HistorySection(_HistoryService, _doctorService, _patientService);
            history.ShowDialog();
        }
        private void btnAllHistory_Click(object sender, RoutedEventArgs e)
        {
            AllHistory history = new AllHistory(_HistoryService);
            history.ShowDialog();
        }
        private void btnDeleteHistory_Click(object sender, RoutedEventArgs e)
        {
            DeleteHistory history = new DeleteHistory(_HistoryService);
            history.ShowDialog();
        }
        private void btnAddPrescription_Click(object sender, RoutedEventArgs e)
        {
            PrescriptionSection prescription = new PrescriptionSection(_prescriptionService, _medicineService, _HistoryService);
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