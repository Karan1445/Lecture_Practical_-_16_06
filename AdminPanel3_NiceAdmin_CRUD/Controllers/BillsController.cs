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
        
        public IActionResult AddBills(int billid) {
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

            SqlCommand UserDropdowncmd = connection.CreateCommand();
            UserDropdowncmd.CommandText = "PR_Bills_UserDropDown";
            UserDropdowncmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader read_Userdata = UserDropdowncmd.ExecuteReader();
            DataTable table_userdata = new DataTable();
            table_userdata.Load(read_Userdata);
            List<UserDropDown> userDropDowns = new List<UserDropDown>();
            foreach (DataRow datarow in table_userdata.Rows) { 
                UserDropDown model = new UserDropDown();
                model.UserID = Convert.ToInt32(datarow["UserID"]);
                model.UserName = datarow["UserName"].ToString();
                userDropDowns.Add(model);
            }
            ViewBag.UserDropDownList=userDropDowns;

            SqlCommand cmdFillUpData = connection.CreateCommand();
            cmdFillUpData.CommandText = "PR_Bills_SelectByPk";
            cmdFillUpData.CommandType=CommandType.StoredProcedure;
            cmdFillUpData.Parameters.Add("@BillID", SqlDbType.Int).Value = billid;
            SqlDataReader reder = cmdFillUpData.ExecuteReader();
            DataTable FillupData = new DataTable();
            FillupData.Load(reder);
            BillsModel Fillupmodel = new BillsModel();
            foreach (DataRow dataModel in FillupData.Rows) {
                Fillupmodel.BillId = Convert.ToInt32(dataModel["BillId"]);
                Fillupmodel.BillDate = Convert.ToDateTime(dataModel["BillDate"]);
                Fillupmodel.BillNumber= Convert.ToString(dataModel["BillNumber"]);
                Fillupmodel.OrderId= Convert.ToInt32(dataModel["OrderId"]);
                Fillupmodel.TotalAmount = Convert.ToInt32(dataModel["TotalAmount"]);
                Fillupmodel.Discount = Convert.ToDouble(dataModel["Discount"]);
                Fillupmodel.NetAmount = Convert.ToInt32(dataModel["NetAmount"]);
                Fillupmodel.UserID = Convert.ToInt32(dataModel["UserID"]);

            }
            return View(Fillupmodel);
        }

        [HttpPost]
        public IActionResult SaveData(BillsModel BillsModel)
        {
            bool Save_or_update = false;
            try
            {
                if (!ModelState.IsValid)
                {

                }
                String sqlConnectionString = this.configuration.GetConnectionString("ConnectionString");
                SqlConnection conneciton = new SqlConnection(sqlConnectionString);
                conneciton.Open();
                SqlCommand cmd = conneciton.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                
                if (BillsModel.BillId == null)
                {
                    cmd.CommandText = "Pr_Bills_Insert";
                    Save_or_update = true;
                }
                else
                {
                    cmd.CommandText = "PR_Bills_UpdateByPK";
                    cmd.Parameters.Add("@BillId", SqlDbType.Int).Value = BillsModel.BillId;
                }
                cmd.Parameters.Add("@BillNumber", SqlDbType.Int).Value = BillsModel.BillNumber;
                cmd.Parameters.Add("@BillDate", SqlDbType.DateTime).Value = BillsModel.BillDate;
                cmd.Parameters.Add("@OrderId", SqlDbType.Int).Value = BillsModel.OrderId;
                cmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = BillsModel.TotalAmount;
                cmd.Parameters.Add("@Discount", SqlDbType.Decimal).Value = BillsModel.Discount;
                cmd.Parameters.Add("@NetAmount", SqlDbType.Decimal).Value = BillsModel.NetAmount;
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = BillsModel.UserID;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e) {
                TempData["ErrorMessage"] = "An error occurred while saving Bill details: " + e.Message;
                return RedirectToAction("Index");
            }
            if (Save_or_update) {
                TempData["SuccessMessage"] = "Bill details have been saved successfully!";
                return RedirectToAction("AddBills");
            }
            TempData["SuccessMessage"] = "Bill details have been Updated successfully!";
            return RedirectToAction("Index");

        }
        public IActionResult EditInController(int billsid) {
            BillsModel fillUpData = bills[billsid];
            return View("AddBills",fillUpData);
        }
     
        public IActionResult DeleteInController(int billsid)
        {
            try
            {
                String connectionStr = configuration.GetConnectionString("ConnectionString");
                SqlConnection connection = new SqlConnection(connectionStr);
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "PR_Bills_DeleteByPK";
                command.Parameters.Add("@BillID", SqlDbType.Int).Value = billsid;
                command.ExecuteNonQuery();
            }
            catch (Exception e) {
                TempData["ErrorMessage"] = "An error occurred while Deleting Bill details: " + e.Message;
                return RedirectToAction("Index");
            }
            TempData["SuccessMessage"] = "Bill details have been Deleted successfully!";
            return RedirectToAction("Index");
        }
       
    }

}
