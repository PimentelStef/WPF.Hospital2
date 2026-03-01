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
    /// Interaction logic for MedicalHistorySection.xaml
    /// </summary>
    public partial class HistorySection : Window
    {
        private readonly IHistoryService _historyService;
        private readonly IDoctorService _doctorService;

        public HistorySection(IHistoryService historyService, IDoctorService doctorService)
        {
            InitializeComponent();

            _historyService = historyService;
            _doctorService = doctorService;

            DataContext = new HistoryViewModel
            {
                Doctors = _doctorService.GetAll()
                    .Select(d => new DoctorViewModel
                    {
                        Id = d.Id,
                        FullName = d.FirstName + " " + d.LastName
                    })
            };
        }

        private void btnAddHistory_Click(object sender, RoutedEventArgs e)
        {
            var vm = (HistoryViewModel)DataContext;

            var result = _historyService.Create(new DTO.History()
            {
                DoctorId = vm.Id,
                Procedure = vm.Procedure
            });

            MessageBox.Show(result.Message);

            if (result.ok)
                this.DialogResult = true;
        }
    }
}
