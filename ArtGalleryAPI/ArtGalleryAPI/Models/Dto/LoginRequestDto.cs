using System.ComponentModel.DataAnnotations;

namespace ArtGalleryAPI.Models.Dto
{
    public class LoginRequestDto
    {
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Invalid Email!")]
        [MaxLength(100, ErrorMessage = "User email can have a maximum of 100 characters!")]
        public required string Email { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "User password can have a maximum of 30 characters!")]
        public required string Password { get; set; }
    }
}
