using Hospital.DataAcess.Data;
using Hospital.DataAcess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DataAcess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IPatientRepository Patient { get; private set; }
        public UnitOfWork(ApplicationDbContext db) 
        {
            _db = db;
            Patient = new PatientRepository(_db);
        }

       

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
