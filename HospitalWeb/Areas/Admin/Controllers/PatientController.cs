using Hospital.DataAcess.Data;
using Hospital.DataAcess.Repository.IRepository;
using Hospital.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PatientController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public PatientController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Patient> objPatientList = _unitOfWork.Patient.GetAll().ToList();
            
            return View(objPatientList);
        }
        public IActionResult Upsert(int? id)
        {

            if (id == null || id == 0)
            {
                // Create

                return View(new Patient());
            }
            else
            {
                // Update

                Patient patientObj = _unitOfWork.Patient.Get(u => u.Id == id);
                return View(patientObj);
            }
            
        }
        [HttpPost]
        public IActionResult Upsert(Patient PatienyObj)
        {
            if (ModelState.IsValid)
            {
                if (PatienyObj.Id == 0)
                {
                    _unitOfWork.Patient.Add(PatienyObj);
                }
                else
                {
                    _unitOfWork.Patient.Update(PatienyObj);
                }

                _unitOfWork.Save();
                TempData["success"] = "Patient's Data Added Successfully";
                return RedirectToAction("Index");
            }

            return View(PatienyObj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Patient? PatientFromDb = _unitOfWork.Patient.Get(u => u.Id == id);

            if (PatientFromDb == null)
            {
                return NotFound();
            }

            return View(PatientFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Patient? obj = _unitOfWork.Patient.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Patient.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Patient's Data Deleted Successfully";
            return RedirectToAction("Index");

        }
    }
}
