using System;
using System.ComponentModel.DataAnnotations;

namespace AdminPanel3_NiceAdmin_CRUD.Models
{
    public class OrderModel
    {
        public int? OrderID { get; set; }

        [Required(ErrorMessage = "Order Date is compulsory.")]
        public DateTime? OrderDate { get; set; }

        [Required(ErrorMessage = "Customer ID is compulsory.")]
        [Range(1, int.MaxValue, ErrorMessage = "Customer ID must be a positive number.")]
        public int? CustomerId { get; set; }

        [Required(ErrorMessage = "Payment Mode is compulsory.")]
        [MaxLength(50, ErrorMessage = "Payment Mode cannot exceed 50 characters.")]
        public string? PaymentMode { get; set; }

        [Required(ErrorMessage = "Total Amount is compulsory.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Total Amount must be greater than zero.")]
        public double? TotalAmount { get; set; }

        [Required(ErrorMessage = "Shipping Address is compulsory.")]
        [MaxLength(200, ErrorMessage = "Shipping Address cannot exceed 200 characters.")]
        public string? ShippingAddress { get; set; }

        [Required(ErrorMessage = "User ID is compulsory.")]
        [Range(1, int.MaxValue, ErrorMessage = "User ID must be a positive number.")]
        public int? UserID { get; set; }
    }
}
