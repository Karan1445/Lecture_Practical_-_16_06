using AdminPanel3_NiceAdmin_CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
namespace AdminPanel3_NiceAdmin_CRUD.Controllers
{
    [CheckAccess]
    public class OrderController : Controller
    {
        #region TestinDATA
        public static List<OrderModel> order = new List<OrderModel>() {
        new OrderModel{OrderID=1,OrderDate=DateTime.Now,CustomerId=1,PaymentMode="upi",TotalAmount=120.22,ShippingAddress="Rajkot",UserID=1},
        new OrderModel{OrderID=1,OrderDate=DateTime.Now,CustomerId=1,PaymentMode="upi",TotalAmount=120.22,ShippingAddress="Rajkot",UserID=1},
        new OrderModel{OrderID=1,OrderDate=DateTime.Now,CustomerId=1,PaymentMode="upi",TotalAmount=120.22,ShippingAddress="Rajkot",UserID=1},
        new OrderModel{OrderID=1,OrderDate=DateTime.Now,CustomerId=1,PaymentMode="upi",TotalAmount=120.22,ShippingAddress="Rajkot",UserID=1},
        new OrderModel{OrderID=1,OrderDate=DateTime.Now,CustomerId=1,PaymentMode="upi",TotalAmount=120.22,ShippingAddress="Rajkot",UserID=1},};
        #endregion
        #region Configure and Constructor
        IConfiguration configuration;
        public OrderController(IConfiguration _config) {
            configuration = _config;
            }
        #endregion
        #region Order method or Index
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
        #endregion
        public IActionResult AddOrder(int OrderID) {
            #region Fill up Order MOdel
            string sqlconnectionstring = this.configuration.GetConnectionString("ConnectionString");
            SqlConnection connection = new SqlConnection(sqlconnectionstring);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "PR_Order_SelectByPk";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Primary_key", SqlDbType.Int).Value = OrderID;
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            OrderModel fillupmodel = new OrderModel();
            foreach (DataRow datarow in dt.Rows) {
                fillupmodel.OrderID = Convert.ToInt32(datarow["OrderID"]);
                fillupmodel.OrderDate =Convert.ToDateTime(datarow["OrderDate"]);
                fillupmodel.CustomerId = Convert.ToInt32(datarow["CustomerId"]);
                fillupmodel.PaymentMode = datarow["PaymentMode"].ToString();
                fillupmodel.TotalAmount = Convert.ToDouble(datarow["TotalAmount"]);
                fillupmodel.ShippingAddress = datarow["ShippingAddress"].ToString();
                fillupmodel.UserID = Convert.ToInt32(datarow["UserID"]);
            }
            #endregion
            #region UserDropDown
            SqlCommand UserDropdowncmd = connection.CreateCommand();
            UserDropdowncmd.CommandText = "PR_Order_UserDropDown";
            UserDropdowncmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader read_Userdata = UserDropdowncmd.ExecuteReader();
            DataTable table_userdata = new DataTable();
            table_userdata.Load(read_Userdata);
            List<UserDropDown> userDropDowns = new List<UserDropDown>();
            foreach (DataRow datarow in table_userdata.Rows)
            {
                UserDropDown model = new UserDropDown();
                model.UserID = Convert.ToInt32(datarow["UserID"]);
                model.UserName = datarow["UserName"].ToString();
                userDropDowns.Add(model);
            }
            ViewBag.UserDropDownList = userDropDowns;
            #endregion
            #region CustomerDropDown
            SqlCommand cd = connection.CreateCommand();
            cd.CommandText="PR_Order_CustomerDropDown";
            cd.CommandType = CommandType.StoredProcedure;
            SqlDataReader rc = cd.ExecuteReader();
            DataTable dc = new DataTable();
            dc.Load(rc);
            List<CustomerDropDownModel> custlist = new List<CustomerDropDownModel>();
            foreach (DataRow drc in dc.Rows) {
                CustomerDropDownModel model = new CustomerDropDownModel();
                model.CustomerID =Convert.ToInt32(drc["CustomerID"]);
                model.CustomerName = drc["CustomerName"].ToString();
                custlist.Add(model);
            }
            ViewBag.custlist = custlist;
            #endregion
            return View(fillupmodel);
        }
        #region Delete
        public IActionResult Delete(int OrderID) {
            
            try
            {
                string conStr = configuration.GetConnectionString("ConnectionString");
                SqlConnection connection = new SqlConnection(conStr);
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PR_Order_DeleteByPK";
                cmd.Parameters.Add("@OrderID", SqlDbType.Int).Value = OrderID;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                if (e.Message.StartsWith("The DELETE statement")) {
                    TempData["ErrorMessage"] = "You Can Not Delete This Record Becuse it is Associated With Other Table's Data";
                }
                TempData["ErrorMessage"] = "An error occurred while Deleting Order details: " + e.Message;
                return RedirectToAction("Order");
            }
            TempData["SuccessMessage"] = "Order details have been Deleted successfully!";
            return RedirectToAction("Order");
        }
        #endregion
        #region PostDATa
        public IActionResult SaveData(OrderModel ordermodel) {
            bool Save_or_update = false;
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["ErrorMessage"] = "An error occurred while saving Order details: " ;
                    return RedirectToAction("Order");
                }
                String sqlConnectionString = this.configuration.GetConnectionString("ConnectionString");
                SqlConnection conneciton = new SqlConnection(sqlConnectionString);
                conneciton.Open();
                SqlCommand cmd = conneciton.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;

                if (ordermodel.OrderID == null)
                {
                    cmd.CommandText = "Pr_Order_Insert";    
                    Save_or_update = true;
                }
                else
                {
                    cmd.CommandText = "PR_Order_UpdateByPK";
                    cmd.Parameters.Add("@OrderID", SqlDbType.Int).Value = ordermodel.OrderID;
                }
                cmd.Parameters.Add("@OrderDate", SqlDbType.DateTime).Value = ordermodel.OrderDate;
                cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = ordermodel.CustomerId;
                cmd.Parameters.Add("@PaymentMode", SqlDbType.NVarChar).Value = ordermodel.PaymentMode;
                cmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = ordermodel.TotalAmount;
                cmd.Parameters.Add("@ShippingAddress", SqlDbType.NVarChar).Value = ordermodel.ShippingAddress;
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = ordermodel.UserID;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = "An error occurred while saving Order details: " + e.Message;
                return RedirectToAction("Order");
            }
            if (Save_or_update)
            {
                TempData["SuccessMessage"] = "Order's details have been Order successfully!";
                return RedirectToAction("AddOrder");
            }
            TempData["SuccessMessage"] = "Order's details have been Updated successfully!";
            return RedirectToAction("Order");
        }
        #endregion
    }
}
