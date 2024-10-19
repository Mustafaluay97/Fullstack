namespace HomeWork.Models
{
    public class Course
    {
        public int Id { get; set; }
        public int ProgramId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public int TrainerId { get; set; } // 
    }
}
