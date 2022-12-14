namespace Domain.Entities;

    public class Course
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credit { get; set; }
   
        public DateTime EnrollmentDate { get; set; }

        public List<Enrollment> Enrollments { get; set; }
    }
