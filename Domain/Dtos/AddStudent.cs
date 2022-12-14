namespace Domain.Dtos;
using Microsoft.AspNetCore.Http;
public class AddStudent {
 public int ID { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public IFormFile? Image { get; set; }
}

