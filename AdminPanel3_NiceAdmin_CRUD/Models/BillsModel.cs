using System.ComponentModel.DataAnnotations;

namespace AdminPanel3_NiceAdmin_CRUD.Models
{
    
    public class BillsModel
    {

        public int? BillId { get; set; }
        [Required(ErrorMessage = "This Field is compulsory")]
        [Range(0, long.MaxValue, ErrorMessage = "Number must be a non-negative number.")]
        public String? BillNumber { get; set; }
        [Required(ErrorMessage = "This Field is compulsory")]
        [DataType(DataType.DateTime)]
        public DateTime? BillDate { get; set; }
        [Required(ErrorMessage = "This Field is compulsory")]
        public int? OrderId { get; set; }
        [Required(ErrorMessage = "This Field is compulsory")]
        public double? TotalAmount { get; set; }
        [Required(ErrorMessage = "This Field is compulsory")]
        public double? Discount {  get; set; }
        [Required(ErrorMessage = "This Field is compulsory")]
        public double? NetAmount {  get; set; }
        [Required(ErrorMessage = "This Field is compulsory")]
        public int? UserID { get; set; }
    }
    public class OrderDropDownModel { 
        public int OrderID { get; set; }
    }
    public class UserDropDown { 
        public int UserID { get; set; }
        public String UserName { get; set; }
    }
}
