using System.ComponentModel.DataAnnotations;

namespace AdminPanel3_NiceAdmin_CRUD.Models
{
    public class ProductModel
    {
        public int? ProductID { get; set; }

        [Required(ErrorMessage = "Product Name is compulsory.")]
        [MaxLength(100, ErrorMessage = "Product Name cannot exceed 100 characters.")]
        public string? ProductName { get; set; }

        [Required(ErrorMessage = "Product Price is compulsory.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Product Price must be greater than zero.")]
        public double? ProductPrice { get; set; }

        [Required(ErrorMessage = "Product Code is compulsory.")]
        [MaxLength(50, ErrorMessage = "Product Code cannot exceed 50 characters.")]
        public string? ProductCode { get; set; }

        [Required(ErrorMessage = "Description is compulsory.")]
        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "User ID is compulsory.")]
        [Range(1, int.MaxValue, ErrorMessage = "User ID must be a positive number.")]
        public int? UserID { get; set; }
    }
    public class ProductDropdownModel { 
        public int ProductID { get; set; }
        public String ProductName { get; set; } 
    }
}
