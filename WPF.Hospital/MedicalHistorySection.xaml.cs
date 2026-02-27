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
    /// Interaction logic for MedicalHistorySection.xaml
    /// </summary>
    public partial class MedicalHistory : Window
    {
        private readonly IHistoryService _historyService;

        public MedicalHistory(IHistoryService historyService)
        {
            InitializeComponent();
            _historyService = historyService;

            DataContext = new HistoryViewModel();
        }

        private void btnAddHistory_Click(object sender, RoutedEventArgs e)
        {
            var vm = (HistoryViewModel)DataContext;

            var result = _historyService.Create(new DTO.History()
            {
                PatientId = vm.PatientId,
                DoctorId = vm.DoctorId,
                Procedure = vm.Procedure
            });

            MessageBox.Show(result.Message);
        }

        private void btnDeleteHistory_Click(object sender, RoutedEventArgs e)
        {
            var vm = (HistoryViewModel)DataContext;

            _historyService.Delete(vm.SelectedHistoryId);

            MessageBox.Show("History deleted!");
        }
    }
}
