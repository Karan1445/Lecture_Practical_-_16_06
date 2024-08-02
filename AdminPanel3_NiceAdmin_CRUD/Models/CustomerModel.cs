using System.ComponentModel.DataAnnotations;

namespace AdminPanel3_NiceAdmin_CRUD.Models
{
    public class CustomerModel
    {
        
        public int CustomerID {  get; set; }
        [Required(ErrorMessage = "This Field is compulsory")]
      
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "This Field is compulsory")]

        [MaxLength(100)]
        public string HomeAddress {  get; set; }
        [Required(ErrorMessage = "This Field is compulsory")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "This Field is compulsory")]
        public string MobileNo { get; set; }
        [Required(ErrorMessage = "This Field is compulsory")]

        public string GST_NO  { get; set; }
        [Required(ErrorMessage = "This Field is compulsory")]
        public string CityName { get;set; }
        [Required(ErrorMessage = "This Field is compulsory")]

        public string PinCode { get; set; }
        [Required(ErrorMessage = "This Field is compulsory")]

        public double NetAmount { get; set; }
        [Required(ErrorMessage = "This Field is compulsory")]
        public int UserID {  get; set; }

    }
}
