using System.ComponentModel.DataAnnotations;

namespace AdminPanel3_NiceAdmin_CRUD.Models
{
    
    public class BillsModel
    {

        public int BillId { get; set; }
        [Required(ErrorMessage = "This Field is compulsory")]
        public String BillNumber { get; set; }
        [Required(ErrorMessage = "This Field is compulsory")]
        public DateTime BillDate { get; set; }
        [Required(ErrorMessage = "This Field is compulsory")]
        public int OrderId { get; set; }
        [Required(ErrorMessage = "This Field is compulsory")]
        public double TotalAmount { get; set; }
        [Required(ErrorMessage = "This Field is compulsory")]
        public double Discount {  get; set; }
        [Required(ErrorMessage = "This Field is compulsory")]
        public double NetAmount {  get; set; }
        [Required(ErrorMessage = "This Field is compulsory")]
        public int UserID { get; set; }
    }
    public class OrderDropDownModel { 
        public int OrderID { get; set; }
    }
}
