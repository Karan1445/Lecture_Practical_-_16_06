namespace AdminPanel3_NiceAdmin_CRUD.Models
{
   
    public class OrderDetailModel
    {
       public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public double Amount { get; set; }
        public double TotaAmount { get;set;}
        public int UserID { get; set; }
    }
}
