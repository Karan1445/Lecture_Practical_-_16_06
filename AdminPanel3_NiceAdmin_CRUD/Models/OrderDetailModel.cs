using System.ComponentModel.DataAnnotations;

namespace AdminPanel3_NiceAdmin_CRUD.Models
{
    public class OrderDetailModel
    {
        public int? OrderDetailID { get; set; }

        [Required(ErrorMessage = "Order ID is compulsory.")]
        [Range(1, int.MaxValue, ErrorMessage = "Order ID must be a positive number.")]
        public int? OrderID { get; set; }

        [Required(ErrorMessage = "Product ID is compulsory.")]
        [Range(1, int.MaxValue, ErrorMessage = "Product ID must be a positive number.")]
        public int? ProductID { get; set; }

        [Required(ErrorMessage = "Quantity is compulsory.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int? Quantity { get; set; }

        [Required(ErrorMessage = "Amount is compulsory.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public double? Amount { get; set; }

        [Required(ErrorMessage = "Total Amount is compulsory.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Total Amount must be greater than zero.")]
        public double? TotalAmount { get; set; }

        [Required(ErrorMessage = "User ID is compulsory.")]
        [Range(1, int.MaxValue, ErrorMessage = "User ID must be a positive number.")]
        public int? UserID { get; set; }
    }
}
