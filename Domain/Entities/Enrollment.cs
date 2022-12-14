namespace Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
    public class Enrollment
    {
      [Key]
        public int EnrolmentID { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public DateTime EnrollmentDate { get; set; }
         public Grade? Grade { get; set; }
           public Student student{get;set;}
           public Course course{get;set;}
       
    }
      public enum Grade
    {
        A, B, C, D, F
    }
