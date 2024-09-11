using System.ComponentModel.DataAnnotations;

namespace AdminPanel3_NiceAdmin_CRUD.Models
{
    public class CustomerModel
    {
        public int? CustomerID { get; set; }

        [Required(ErrorMessage = "Customer Name is required.")]
        [MaxLength(50, ErrorMessage = "Customer Name cannot exceed 50 characters.")]
        public string? CustomerName { get; set; }

        [Required(ErrorMessage = "Home Address is required.")]
        [MaxLength(100, ErrorMessage = "Home Address cannot exceed 100 characters.")]
        public string? HomeAddress { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Mobile Number is required.")]
        [Phone(ErrorMessage = "Invalid Mobile Number format.")]
        [MaxLength(15, ErrorMessage = "Mobile Number cannot exceed 15 digits.")]
        public string? MobileNo { get; set; }

        [Required(ErrorMessage = "GST Number is required.")]
        [RegularExpression(@"^[0-9]{2}[A-Z]{5}[0-9]{4}[A-Z]{1}[A-Z0-9]{1}[Z]{1}[A-Z0-9]{1}$",
            ErrorMessage = "Invalid GST Number format.")]
        public string? GST_NO { get; set; }

        [Required(ErrorMessage = "City Name is required.")]
        public string? CityName { get; set; }

        [Required(ErrorMessage = "Pin Code is required.")]
        [RegularExpression(@"^\d{6}$", ErrorMessage = "Invalid Pin Code format.")]
        public string? PinCode { get; set; }

        [Required(ErrorMessage = "Net Amount is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Net Amount must be a positive number.")]
        public double? NetAmount { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        public int? UserID { get; set; }
    }
    public class CustomerDropDownModel { 
    public int CustomerID { get; set; }
        public String CustomerName { get; set; }
    }
    
}
