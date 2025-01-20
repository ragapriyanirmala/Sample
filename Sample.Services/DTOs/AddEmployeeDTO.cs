using System.ComponentModel.DataAnnotations;

namespace Sample.Services.DTOs
{
    public class AddEmployeeDTO
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Name has been Max. 100 characters")]
        public string Name { get; set; }
        [Required]
        [MaxLength(500, ErrorMessage = "Address has been Max. 500 characters")]
        public string Address { get; set; }
        public string? EmployeeImageUrl { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Code has been Min. 3 characters")]
        [MaxLength(3, ErrorMessage = "Code has been Max. 3 characters")]
        public string BranchCode { get; set; }
        [Required]
        public string TeamName { get; set; }

    }
}
