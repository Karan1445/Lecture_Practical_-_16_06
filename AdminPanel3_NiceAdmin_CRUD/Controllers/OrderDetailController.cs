using AdminPanel3_NiceAdmin_CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace AdminPanel3_NiceAdmin_CRUD.Controllers
{
    public class OrderDetailController : Controller
    {
        public static List<OrderDetailModel> orderDetails = new List<OrderDetailModel>() {
        new OrderDetailModel{OrderID=1,OrderDetailID=1,ProductID=1,Quantity=10,Amount=120,TotaAmount=1200,UserID=1 }
        };
        public IConfiguration configuration;
        public OrderDetailController(IConfiguration config) {
            configuration = config;
        }
        public IActionResult orderDetail()
        {
            string sqlconnectionstring = this.configuration.GetConnectionString("ConnectionString");
            SqlConnection connection = new SqlConnection(sqlconnectionstring);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "PR_OrderDetail_SelectAll";
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            return View(dt);
        }
        public IActionResult AddOrderDetail() {
            return View();
        }
        public IActionResult AddInController(OrderDetailModel newData) {
            newData.OrderDetailID = orderDetails.Count + 1;
            orderDetails.Add(newData);
            return View("orderDetail",orderDetails);
        }
    }
}
