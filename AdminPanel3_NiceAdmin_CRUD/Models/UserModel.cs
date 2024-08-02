using System.ComponentModel.DataAnnotations;

namespace AdminPanel3_NiceAdmin_CRUD.Models
{
    public class UserModel
    {
        public int UserID { get; set; }
        [Required(ErrorMessage ="This feild is Compulsory")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "This feild is Compulsory")]
        public string Email { get; set; }
        [Required(ErrorMessage = "This feild is Compulsory")]
        public string Password { get; set; }
        [Required(ErrorMessage = "This feild is Compulsory")]
        public string MobileNo { get; set; }
        [Required(ErrorMessage = "This feild is Compulsory")]
        public string Address { get; set; }
        [Required(ErrorMessage = "This feild is Compulsory")]
        public bool IsActive { get; set; }

    }
}
