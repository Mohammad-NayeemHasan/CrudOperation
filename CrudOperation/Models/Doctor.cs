namespace CrudOperation.Models
{
    public class Doctor
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Specialization { get; set; } = null!;
        public string Phone { get; set; } = null!;

        // Navigation Property (One Doctor → Many Appointments)
        public virtual List<Appointment> Appointments { get; set; } = new();
    }

}
