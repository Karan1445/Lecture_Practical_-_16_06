using System.ComponentModel.DataAnnotations;

namespace AdminPanel3_NiceAdmin_CRUD.Models
{
    public class ProductModel
    {
        public int ProductID { get; set; }
        [Required(ErrorMessage = "This feild is Compulsory")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "This feild is Compulsory")]
        public double ProductPrice { get; set; }
        [Required(ErrorMessage = "This feild is Compulsory")]
        public  string ProductCode { get; set; }
         [Required(ErrorMessage ="This feild is Compulsory")]
        public string Description { get; set; }
        [Required(ErrorMessage = "This feild is Compulsory")]
        public int UserID { get; set; }
    }
}
