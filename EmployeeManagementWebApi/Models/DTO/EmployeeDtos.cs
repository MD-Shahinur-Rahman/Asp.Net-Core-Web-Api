using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementWebApi.Models.DTO
{
    public class EmployeeDtos
    {
        [Required]
        public string EmployeeName { get; set; }
        public bool IsActive { get; set; }
        [Required, RegularExpression(@"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$")]
        public string Email { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime JoinDate { get; set; }
        public IFormFile ImgFile { get; set; }
        public string ImageName { get; set; }
        public string Experiences { get; set; }
    }
}
