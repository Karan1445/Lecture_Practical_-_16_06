using AdminPanel3_NiceAdmin_CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace AdminPanel3_NiceAdmin_CRUD.Controllers
{
    public class BillsController : Controller
    {
      
        public int lastid;
        public static List<BillsModel> bills = new List<BillsModel>() { 
        };
        public IConfiguration configuration;
        public BillsController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public IActionResult Index()
        {

            string connectionstring = this.configuration.GetConnectionString("ConnectionString");
            SqlConnection connection = new SqlConnection(connectionstring);
            connection.Open();
            SqlCommand command = connection.CreateCommand();
            command.CommandType=System.Data.CommandType.StoredProcedure;
            command.CommandText = "PR_Bills_SelectAll";
            SqlDataReader reader = command.ExecuteReader();
            DataTable dt=new DataTable();
            dt.Load(reader);
            return View(dt);
        }
        
        public IActionResult AddBills() {
            string connectionStr = configuration.GetConnectionString("ConnectionString");
            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "PR_Bills_DropDown";
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            List<OrderDropDownModel> OrderIDList = new List<OrderDropDownModel>();
            foreach (DataRow datarow in dt.Rows)
            {
                OrderDropDownModel orderddmode = new OrderDropDownModel();
                orderddmode.OrderID = Convert.ToInt32(datarow["OrderID"]);
                OrderIDList.Add(orderddmode);
            }
            ViewBag.OrderDropDown = OrderIDList;

            return View();
        }
        [HttpPost]
        public IActionResult AddDataInController(BillsModel newData)
        {

            //if (ModelState.IsValid)
            //{
            //    if (newData.BillId != null)
            //    {
            //        bills.RemoveAt(newData.BillId);
            //        bills.Insert(newData.BillId, newData);

            //        return View("Index", bills);
            //    }

            //    newData.BillId = bills.Max(x => x.BillId) + 1;
            //    bills.Add(newData);
            //    return View("Index", bills);
            //}
            //else {

            //}
       
            return View("Index");
        }
        public IActionResult EditInController(int billsid) {
            BillsModel fillUpData = bills[billsid];
            return View("AddBills",fillUpData);
        }
        public IActionResult DeleteInController(int Billsid)
        {
            String connectionStr = configuration.GetConnectionString("ConnectionString");
            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();
            SqlCommand command=connection.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "PR_Bills_DeleteByPK";    
            command.Parameters.Add("@BillID",SqlDbType.Int).Value=Billsid;
            command.ExecuteNonQuery();
            return View("Index");
        }
    }
}
