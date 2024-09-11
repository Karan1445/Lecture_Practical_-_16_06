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
        public IActionResult AddCustomer(int CustomerID) {
            string connectionString = this.configuration.GetConnectionString("ConnectionString");
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            #region CustomerDataFillUp
            SqlCommand command = connection.CreateCommand();
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = "PR_Customer_SelectByPk";
            command.Parameters.Add("@Primary_key", SqlDbType.Int).Value = CustomerID;
            SqlDataReader reader = command.ExecuteReader();
            DataTable Datafilluptable=new DataTable();
            Datafilluptable.Load(reader);
            CustomerModel CustomerFillupModel = new CustomerModel();

            foreach (DataRow dr in Datafilluptable.Rows) {
                CustomerFillupModel.CustomerID = Convert.ToInt32(dr["CustomerID"]);
                CustomerFillupModel.CustomerName = dr["CustomerName"].ToString();
                CustomerFillupModel.HomeAddress = dr["HomeAddress"].ToString();
                CustomerFillupModel.Email = dr["Email"].ToString();
                CustomerFillupModel.MobileNo = dr["MobileNo"].ToString();
                CustomerFillupModel.GST_NO = dr["GST_NO"].ToString();
                CustomerFillupModel.CityName = dr["CityName"].ToString();
                CustomerFillupModel.PinCode = dr["PinCode"].ToString();
                CustomerFillupModel.NetAmount =Convert.ToInt32(dr["NetAmount"]);
                CustomerFillupModel.UserID = Convert.ToInt32(dr["UserID"]);
            }
            #endregion
            #region UserDropDown
            SqlCommand UserFillupCommand = connection.CreateCommand();
            UserFillupCommand.CommandText = "PR_Customer_UserDropDown";
            UserFillupCommand.CommandType = CommandType.StoredProcedure;
            SqlDataReader rd = UserFillupCommand.ExecuteReader();
            DataTable Userdropdowntable = new DataTable();
            Userdropdowntable.Load(rd);
            List<UserDropDown> UserDropDownList = new List<UserDropDown>();
            foreach (DataRow datarow in Userdropdowntable.Rows) {
                UserDropDown model = new UserDropDown();
                model.UserID = Convert.ToInt32(datarow["UserID"]);
                model.UserName = datarow["UserName"].ToString();
                UserDropDownList.Add(model);
            }
            ViewBag.UserDropDownList = UserDropDownList;
            #endregion
            return View(CustomerFillupModel);
        }
        [HttpPost]
        public IActionResult SaveData(CustomerModel customermodel) {
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

                if (customermodel.CustomerID ==null)
                {
                    cmd.CommandText = "Pr_Customer_Insert";
                    Save_or_update = true;
                }
                else
                {
                    cmd.CommandText = "PR_Customer_UpdateByPK";
                    cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = customermodel.CustomerID;
                }
                cmd.Parameters.Add("@CustomerName", SqlDbType.NVarChar).Value = customermodel.CustomerName;
                cmd.Parameters.Add("@HomeAddress", SqlDbType.NVarChar).Value = customermodel.HomeAddress;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = customermodel.Email;
                cmd.Parameters.Add("@MobileNo", SqlDbType.NVarChar).Value = customermodel.MobileNo;
                cmd.Parameters.Add("@gstNo", SqlDbType.NVarChar).Value = customermodel.GST_NO;
                cmd.Parameters.Add("@CityName", SqlDbType.NVarChar).Value = customermodel.CityName;
                cmd.Parameters.Add("@NetAmount", SqlDbType.Decimal).Value = customermodel.NetAmount;
                cmd.Parameters.Add("@PinCode", SqlDbType.NVarChar).Value = customermodel.PinCode;
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = customermodel.UserID;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = "An error occurred while Updating Customer details: " + e.Message;
               
            }
            if (Save_or_update)
            {
                TempData["SuccessMessage"] = "Customer details have been saved successfully!";
                return RedirectToAction("AddCustomer");
            }
            else {
                TempData["SuccessMessage"] = "Customer details have been Updated successfully!";

                return RedirectToAction("Index");

            }

        }




        public IActionResult DeleteInCustomer(int CustomerID)
        {
            try
            {
                string conStr = configuration.GetConnectionString("ConnectionString");
                SqlConnection connection = new SqlConnection(conStr);
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PR_Customer_DeleteByPK";
                cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = CustomerID;
                cmd.ExecuteNonQuery();

            }
            catch(Exception e){
                TempData["ErrorMessage"] = "An error occurred while Deleating Custimer details: " + e.Message;
                return RedirectToAction("Index");
            }
            TempData["SuccessMessage"] = "Customer details have been Deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
