using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Hospital.ViewModel
{
    public class PrescriptionViewModel
    {
        public ObservableCollection<Prescription> Prescriptions { get; set; } = new();

        public void AddPrescription()
        {
            var result = _service.Create(new Prescription
            {
                HistoryId = SelectedHistory.Id,
                MedicineId = SelectedMedicine.Id,
                Quantity = Quantity,
                Frequency = Frequency
            });

            MessageBox.Show(result.Message);

            if (result.Ok)
            {
                LoadPrescriptions(SelectedHistory.Id);
                Quantity = 0;
                Frequency = "";
            }
        }
    }
}
