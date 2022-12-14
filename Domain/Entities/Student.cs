namespace Domain.Entities;

    public class Student
    {
        public int ID { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
   
        public DateTime EnrollmentDate { get; set; }

        public List<Enrollment> Enrollments { get; set; }
         public string? ImageName{get;set;}
    }
