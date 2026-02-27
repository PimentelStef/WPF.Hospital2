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
    /// Interaction logic for AllPrescriptions.xaml
    /// </summary>
    public partial class AllPrescriptions : Window
    {
        private readonly IPrescriptionService _prescriptionService;

        public AllPrescriptions(IPrescriptionService prescriptionService)
        {
            InitializeComponent();
            _prescriptionService = prescriptionService;

            DataContext = new
            {
                Prescriptions = _prescriptionService.GetByHistoryId(0)
                    .Select(p => new PrescriptionViewModel()
                    {
                        Id = p.Id,
                        Frequency = p.Frequency
                    })
            };
        }
    }
}
