using System.ComponentModel.DataAnnotations;

namespace AdminPanel3_NiceAdmin_CRUD.Models
{
    public class UserModel
    {
        public int? UserID { get; set; }

        [Required(ErrorMessage = "Username is compulsory.")]
        [MaxLength(100, ErrorMessage = "Username cannot exceed 100 characters.")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Email is compulsory.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is compulsory.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Mobile Number is compulsory.")]
        [Phone(ErrorMessage = "Invalid mobile number format.")]
        [MaxLength(15, ErrorMessage = "Mobile Number cannot exceed 15 digits.")]
        [MinLength(9,ErrorMessage ="Please Enter Valid mobile number")]
        public string? MobileNo { get; set; }

        [Required(ErrorMessage = "Address is compulsory.")]
        [MaxLength(200, ErrorMessage = "Address cannot exceed 200 characters.")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "IsActive status is compulsory.")]
        public bool? IsActive { get; set; }
    }
    public class UserLogin {
        [Required(ErrorMessage = "UserName is compulsory.")]
        [Display(Name ="UserName")]
        public String? UserName { get; set; }
        [Required(ErrorMessage = "Password is compulsory.")]
        [Display(Name = "PassWord")]
        public String? Password { get; set; }
    }
}
