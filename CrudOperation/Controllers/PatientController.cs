using CrudOperation.Models;
using CrudOperation.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudOperation.Controllers
{
    public class PatientController : Controller
    {
        private readonly IRepository<Patient> _patientRepo;

        public PatientController(IRepository<Patient> patientRepo)
        {
            _patientRepo = patientRepo;
        }
        public async Task<IActionResult> Index()
        {
            
            var patients = await _patientRepo.GetAll(q=>q.Include(q=>q.Appointments)
            .ThenInclude(q=>q.Doctor));
            return View(patients);
        }
    }
}
