namespace AdminPanel3_NiceAdmin_CRUD.Models
{
    
    public class BillsModel
    {
        public int BillId { get; set; }
        public String BillNumber { get; set; }
        public DateTime BillDate { get; set; }
        public int OrderId { get; set; }
        public double TotalAmount { get; set; }
        public double Discount {  get; set; }
        public double NetAmount {  get; set; }
        public int UserID { get; set; }
    }
}
