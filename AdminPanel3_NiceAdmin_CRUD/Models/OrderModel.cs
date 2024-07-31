namespace AdminPanel3_NiceAdmin_CRUD.Models
{
    public class OrderModel
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; } 
        public int CustomerId { get; set; }
        public string PaymentMode { get; set; }
        public double TotalAmount { get; set; }
        public string ShippingAddress { get; set; }
        public int UserID { get; set; }
     }
}
