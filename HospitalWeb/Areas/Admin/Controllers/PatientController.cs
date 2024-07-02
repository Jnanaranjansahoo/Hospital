using Hospital.DataAcess.Data;
using Hospital.DataAcess.Repository.IRepository;
using Hospital.Models;
using Microsoft.AspNetCore.Hosting;
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

        #region API Class
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Patient> objPatientList = _unitOfWork.Patient.GetAll().ToList();
            return Json(new {data = objPatientList});
        }
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var PatientToBeDeleted = _unitOfWork.Patient.Get(u => u.Id == id);
            if (PatientToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.Patient.Remove(PatientToBeDeleted);
            _unitOfWork.Save();


            return Json(new { success = true, message = "Delete Successful" });
        }
        #endregion 
    }
}
