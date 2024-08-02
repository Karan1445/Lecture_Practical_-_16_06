using System.ComponentModel.DataAnnotations;

namespace AdminPanel3_NiceAdmin_CRUD.Models
{
    public class OrderModel
    {
        public int OrderID { get; set; }
        [Required(ErrorMessage = "This feild is Compulsory")]
        public DateTime OrderDate { get; set; }
        [Required(ErrorMessage = "This feild is Compulsory")]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "This feild is Compulsory")]
        public string PaymentMode { get; set; }
        [Required(ErrorMessage = "This feild is Compulsory")]

        public double TotalAmount { get; set; }
        [Required(ErrorMessage = "This feild is Compulsory")]
        public string ShippingAddress { get; set; }
        [Required(ErrorMessage = "This feild is Compulsory")]
        public int UserID { get; set; }
     }
}
