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
    /// Interaction logic for DeleteHistory.xaml
    /// </summary>
    public partial class DeleteHistory : Window
    {
        private readonly IHistoryService _historyService;

        public DeleteHistory(IHistoryService historyService)
        {
            InitializeComponent();
            _historyService = historyService;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtHistoryId.Text))
            {
                MessageBox.Show("History ID is required.");
                return;
            }

            int historyId;

            if (!int.TryParse(txtHistoryId.Text, out historyId))
            {
                MessageBox.Show("History ID must be a number.");
                return;
            }

            _historyService.Delete(historyId);

            MessageBox.Show("History deleted successfully!");
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
