using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Hospital.Model;
using WPF.Hospital.Repository;
using WPF.Hospital.Service;
public class MedicineService : IMedicineService
{
    private readonly IMedicineRepository _repo;

    public MedicineService(IMedicineRepository repo)
    {
        _repo = repo;
    }

    public Medicine Get(int id) => _repo.Get(id);

    public IEnumerable<Medicine> GetAll() => _repo.GetAll();

    public void Add(Medicine med)
    {
        if (string.IsNullOrWhiteSpace(med.Name) ||
            string.IsNullOrWhiteSpace(med.Brand))
            throw new Exception("Medicine name and brand required");

        _repo.Add(med);
    }

    public void Delete(int id)
    {
        _repo.Delete(id);
    }
}
