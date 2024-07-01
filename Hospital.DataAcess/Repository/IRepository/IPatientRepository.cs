using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DataAcess.Repository.IRepository
{
    public interface IPatientRepository :IRepository<Patient>
    {
        void Update (Patient obj);
        
    }
}
