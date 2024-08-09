using AdminPanel3_NiceAdmin_CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
namespace AdminPanel3_NiceAdmin_CRUD.Controllers
{
    public class OrderController : Controller
    {
        public static List<OrderModel> order = new List<OrderModel>() {
        new OrderModel{OrderID=1,OrderDate=DateTime.Now,CustomerId=1,PaymentMode="upi",TotalAmount=120.22,ShippingAddress="Rajkot",UserID=1},
        new OrderModel{OrderID=1,OrderDate=DateTime.Now,CustomerId=1,PaymentMode="upi",TotalAmount=120.22,ShippingAddress="Rajkot",UserID=1},
        new OrderModel{OrderID=1,OrderDate=DateTime.Now,CustomerId=1,PaymentMode="upi",TotalAmount=120.22,ShippingAddress="Rajkot",UserID=1},
        new OrderModel{OrderID=1,OrderDate=DateTime.Now,CustomerId=1,PaymentMode="upi",TotalAmount=120.22,ShippingAddress="Rajkot",UserID=1},
        new OrderModel{OrderID=1,OrderDate=DateTime.Now,CustomerId=1,PaymentMode="upi",TotalAmount=120.22,ShippingAddress="Rajkot",UserID=1},};
        IConfiguration configuration;
        public OrderController(IConfiguration _config) {
            configuration = _config;
            }
        public IActionResult Order()
        {
            string sqlconnectionstring = this.configuration.GetConnectionString("ConnectionString");
            SqlConnection connection =new SqlConnection(sqlconnectionstring);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "PR_Order_SelectAll";
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            return View(dt);
        }
        public IActionResult AddOrder() {
            return View();
        }
        public IActionResult AddInController(OrderModel newData) {
            newData.OrderID = order.Count + 1;
            order.Add(newData);
            return View("Order", order);
            }
    }
}
