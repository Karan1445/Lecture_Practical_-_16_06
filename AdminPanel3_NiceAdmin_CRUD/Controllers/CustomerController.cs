using AdminPanel3_NiceAdmin_CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
namespace AdminPanel3_NiceAdmin_CRUD.Controllers
{
    public class CustomerController : Controller
    {
        public static List<CustomerModel> customers = new List<CustomerModel>()
        {
         new CustomerModel{ CustomerID=1,CustomerName="karan",HomeAddress="Rajkot",Email="goheljitu164@gmail.com",MobileNo="8141953822",GST_NO="124555sd5455",CityName="Rajkot",PinCode="360003",NetAmount=150,UserID=1},
        };
        IConfiguration configuration;
        public CustomerController(IConfiguration _configuration) {
            configuration = _configuration;
        }
        public IActionResult Index()
        {
            string connectionString = this.configuration.GetConnectionString("ConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType=System.Data.CommandType.StoredProcedure;
            command.CommandText = "PR_Customer_SelectAll";
            SqlDataReader reader = command.ExecuteReader();
            Console.WriteLine("-------------------------------------------------------------------");
         
            DataTable dt = new DataTable();
            dt.Load(reader);
            return View(dt);
        }
        public IActionResult AddCustomer() {
            return View();
        }
        public IActionResult AddInCustomer(CustomerModel newData) {
            newData.CustomerID = customers.Count + 1;
            customers.Add(newData);
            return View("Index",customers);
        }
        public IActionResult DeleteInCustomer(int CustomerID)
        {
            string conStr = configuration.GetConnectionString("ConnectionString");
            SqlConnection connection = new SqlConnection(conStr);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_Customer_DeleteByPK";
            cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value=CustomerID;
            cmd.ExecuteNonQuery();
            return RedirectToAction("Index");
        }
    }
}
