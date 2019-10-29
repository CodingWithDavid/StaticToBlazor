
using System.ComponentModel.DataAnnotations;

namespace StaticToBlazorPart5.Models
{
    public class ContactMeModel
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [MinLength(10, ErrorMessage = "Please enter valid phone number")]
        [MaxLength(12, ErrorMessage = "Please enter valid phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "A valid email must be provided")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "A message must be entered")]
        [MaxLength(1000)]
        public string Message { get; set; }
    }
}
