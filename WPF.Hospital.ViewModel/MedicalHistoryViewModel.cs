using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Hospital.ViewModel
{
    public class MedicalHistoryViewModel
    {
        public ObservableCollection<History> Histories { get; set; } = new();

        public void AddHistory()
        {
            var result = _historyService.Create(new History
            {
                PatientId = SelectedPatient.Id,
                DoctorId = SelectedDoctor.Id,
                Procedure = ProcedureText
            });

            MessageBox.Show(result.Message);

            if (result.Ok)
            {
                LoadHistory(SelectedPatient.Id);
                ProcedureText = "";
            }
        }
    }
}
