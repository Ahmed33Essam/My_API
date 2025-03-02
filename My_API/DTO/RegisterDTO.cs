using System.ComponentModel.DataAnnotations;

namespace My_API.DTO
{
    public class RegisterDTO
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(8,MinimumLength = 3)]
        public string Password { get; set; }
    }
}
