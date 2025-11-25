using CrudOperation.Models;

namespace CrudOperation.ViewModels
{
    public class PatientCreateViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string Phone { get; set; } = null!;
        public string Address { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public IFormFile Picture { get; set; } = default!;

        // Navigation Property (One Patient → Many Appointments)
        public virtual List<Appointment> Appointments { get; set; } = new();
    }
}
