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
            if (!int.TryParse(txtHistoryId.Text, out int id))
            {
                MessageBox.Show("Invalid History ID.");
                return;
            }

            bool deleted = _historyService.Delete(id);

            MessageBox.Show(deleted
                ? "History deleted successfully!"
                : "History not found.");

            if (deleted)
                this.Close();
        }
    }
}
