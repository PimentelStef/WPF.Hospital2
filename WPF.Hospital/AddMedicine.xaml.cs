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
    /// Interaction logic for AddMedicine.xaml
    /// </summary>
    public partial class AddMedicine : Window
    {
        private readonly IMedicineService _medicineService;

        public AddMedicine(IMedicineService medicineService)
        {
            InitializeComponent();
            _medicineService = medicineService;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Invalid price.");
                return;
            }

            _medicineService.Add(new DTO.Medicine()
            {
                Name = txtName.Text,
                Brand = txtBrand.Text,
                Price = price
            });

            MessageBox.Show("Medicine added successfully!");
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
