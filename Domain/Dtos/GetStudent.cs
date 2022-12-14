
namespace Domain.Dtos;
public class GetStudent {
        public int ID { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public DateTime EnrollmentDate { get; set; }
         public string? ImageName { get; set; }

}