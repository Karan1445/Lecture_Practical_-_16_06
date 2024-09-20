using AdminPanel3_NiceAdmin_CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace AdminPanel3_NiceAdmin_CRUD.Controllers
{
    [CheckAccess]
    public class OrderDetailController : Controller
    {
        #region extradata
        public static List<OrderDetailModel> orderDetails = new List<OrderDetailModel>() {
        new OrderDetailModel{OrderID=1,OrderDetailID=1,ProductID=1,Quantity=10,Amount=120,TotalAmount=1200,UserID=1 }
        };
        #endregion
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
        public IActionResult AddOrderDetail(int OrderDetailId)
        {
            #region Fill up Order MOdel
            string sqlconnectionstring = this.configuration.GetConnectionString("ConnectionString");
            SqlConnection connection = new SqlConnection(sqlconnectionstring);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "PR_OrderDetail_SelectByPk";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Primary_key", SqlDbType.Int).Value = OrderDetailId;
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            OrderDetailModel fillupmodel = new OrderDetailModel();
            foreach (DataRow datarow in dt.Rows)
            {
                fillupmodel.OrderID = Convert.ToInt32(datarow["OrderID"]);
                fillupmodel.OrderDetailID = Convert.ToInt32(datarow["OrderDetailID"]);
                fillupmodel.ProductID = Convert.ToInt32(datarow["ProductID"]);
                fillupmodel.Quantity =Convert.ToInt32(datarow["Quantity"]);
                fillupmodel.TotalAmount = Convert.ToDouble(datarow["TotalAmount"]);
                fillupmodel.Amount =Convert.ToInt32(datarow["Amount"]);
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
            #region ProductDropDown
            SqlCommand cd = connection.CreateCommand();
            cd.CommandText = "PR_ProductDropDown";
            cd.CommandType = CommandType.StoredProcedure;
            SqlDataReader rc = cd.ExecuteReader();
            DataTable dc = new DataTable();
            dc.Load(rc);
            List<ProductDropdownModel> custlist = new List<ProductDropdownModel>();
            foreach (DataRow drc in dc.Rows)
            {
                ProductDropdownModel model = new ProductDropdownModel();
                model.ProductID = Convert.ToInt32(drc["ProductID"]);
                model.ProductName = drc["ProductName"].ToString();
                custlist.Add(model);
            }
            ViewBag.Prodlist = custlist;
            #endregion
            #region OrderDropDown
            SqlCommand cmd1 = connection.CreateCommand();
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.CommandText = "PR_Bills_DropDown";
            SqlDataReader reader1 = cmd1.ExecuteReader();
            DataTable dt1 = new DataTable();
            dt1.Load(reader1);
            List<OrderDropDownModel> OrderIDList = new List<OrderDropDownModel>();
            foreach (DataRow datarow in dt1.Rows)
            {
                OrderDropDownModel orderddmode = new OrderDropDownModel();
                orderddmode.OrderID = Convert.ToInt32(datarow["OrderID"]);
                OrderIDList.Add(orderddmode);
            }
            ViewBag.OrderDropDown = OrderIDList;
            #endregion
            return View(fillupmodel);
        }
        public IActionResult Delete(int OrderDetailId) {
            #region Delete
            try
            {
                string conStr = configuration.GetConnectionString("ConnectionString");
                SqlConnection connection = new SqlConnection(conStr);
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PR_OrderDetail_DeleteByPK";
                cmd.Parameters.Add("@OrderDetailID", SqlDbType.Int).Value = OrderDetailId;
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = "An error occurred while Deleteing OrderDetails's details: " + e.Message;
                return RedirectToAction("orderDetail");
            }
            TempData["SuccessMessage"] = "Orderdetails's details have been Deleted successfully!";
            return RedirectToAction("orderDetail");
            #endregion
        }
        public IActionResult AddInController(OrderDetailModel newData) {
            newData.OrderDetailID = orderDetails.Count + 1;
            orderDetails.Add(newData);
            return View("orderDetail",orderDetails);
        }
        [HttpPost]
        public IActionResult SaveData(OrderDetailModel orderdetailmodel) {
            #region savedata
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

                if (orderdetailmodel.OrderDetailID == null)
                {
                    cmd.CommandText = "Pr_OrderDetail_Insert";
                    Save_or_update = true;
                }
                else
                {
                    cmd.CommandText = "PR_OrderDetail_UpdateByPK";
                    cmd.Parameters.Add("@OrderDetailID", SqlDbType.Int).Value = orderdetailmodel.OrderDetailID;
                }
                cmd.Parameters.Add("@OrderID", SqlDbType.Int).Value = orderdetailmodel.OrderID;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = orderdetailmodel.ProductID;
                cmd.Parameters.Add("@Quality", SqlDbType.Int).Value = orderdetailmodel.Quantity;
                cmd.Parameters.Add("@TotalAmount", SqlDbType.Decimal).Value = orderdetailmodel.TotalAmount;
                cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = orderdetailmodel.Amount;
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = orderdetailmodel.UserID;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = "An error occurred while saving OrderDetails's details: " + e.Message;
                return RedirectToAction("orderDetail");
            }
            if (Save_or_update)
            {
                TempData["SuccessMessage"] = "Orderdetails's details have been saved successfully!";
                return RedirectToAction("AddOrderDetail");
            }
            TempData["SuccessMessage"] = "OrderDeatials's details have been Updated successfully!";
            return RedirectToAction("orderDetail");
        }
        #endregion
    }
}
