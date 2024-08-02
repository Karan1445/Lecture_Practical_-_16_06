using System.ComponentModel.DataAnnotations;

namespace AdminPanel3_NiceAdmin_CRUD.Models
{
   
    public class OrderDetailModel
    {
       public int OrderDetailID { get; set; }
        [Required(ErrorMessage = "This feild is Compulsory")]
        public int OrderID { get; set; }
        [Required(ErrorMessage = "This feild is Compulsory")]
        public int ProductID { get; set; }
        [Required(ErrorMessage = "This feild is Compulsory")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "This feild is Compulsory")]
        public double Amount { get; set; }
        [Required(ErrorMessage = "This feild is Compulsory")]
        public double TotaAmount { get;set;}
        [Required(ErrorMessage = "This feild is Compulsory")]
        public int UserID { get; set; }
    }
}
