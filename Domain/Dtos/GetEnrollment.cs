namespace Domain.Entities;

    public class GetEnrollment
    {
        public int EnrolmentID { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public DateTime EnrollmentDate { get; set; }
         public Grade? Grade { get; set; }

       
    }