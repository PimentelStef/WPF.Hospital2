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
    /// Interaction logic for AllHistory.xaml
    /// </summary>
    public partial class AllHistory : Window
    {
        private readonly IHistoryService _historyService;

        public AllHistory(IHistoryService historyService)
        {
            InitializeComponent();
            _historyService = historyService;

            DataContext = new
            {
                Histories = _historyService.GetByPatientId(SelectedPatientId)
                    .Select(h => new HistoryViewModel()
                    {
                        Id = h.Id,
                        Procedure = h.Procedure
                    })
            };
        }
    }
}
