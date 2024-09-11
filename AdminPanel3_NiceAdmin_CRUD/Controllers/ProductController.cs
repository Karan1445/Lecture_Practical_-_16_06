using AdminPanel3_NiceAdmin_CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace AdminPanel3_NiceAdmin_CRUD.Controllers
{
    public class ProductController : Controller
    {
        public static List<ProductModel> products = new List<ProductModel>
        {
            new ProductModel{ ProductID=1,ProductName="TailorManagementSystem",ProductCode="1223455",ProductPrice=120.52,Description="About Manage Project of Employee",UserID=1},
                  new ProductModel{ ProductID=2,ProductName="GarbageManagementSystem",ProductCode="1223456",ProductPrice=58.0,Description="About Manage Project of Garbage",UserID=2},
                  new ProductModel{ ProductID=3,ProductName="MobikeManagementSystem",ProductCode="1223457",ProductPrice=90.0,Description="About Manage Project of Mobile",UserID=3},
        };
        public IConfiguration configuration;
        public ProductController(IConfiguration config) {
            configuration = config;
        }
        public IActionResult Prodcut()
        {

            string sqlconnectionstring = this.configuration.GetConnectionString("ConnectionString");
            SqlConnection connection = new SqlConnection(sqlconnectionstring);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "PR_Product_SelectAll";
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            return View(dt);    
        }
        public IActionResult AddProduct(int ProductID) {
            #region userdropdown
            string sqlconnectionstring = this.configuration.GetConnectionString("ConnectionString");
            SqlConnection connection = new SqlConnection(sqlconnectionstring);
            connection.Open();
            SqlCommand UserDropdowncmd = connection.CreateCommand();
            UserDropdowncmd.CommandText = "PR_Bills_UserDropDown";
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
            #region Prodcut data fill
            SqlCommand cmdFillUpData = connection.CreateCommand();
            cmdFillUpData.CommandText = "PR_Product_SelectByPk";
            cmdFillUpData.CommandType = CommandType.StoredProcedure;
            cmdFillUpData.Parameters.Add("@ProductID", SqlDbType.Int).Value = ProductID;
            SqlDataReader reder = cmdFillUpData.ExecuteReader();
            DataTable FillupData = new DataTable();
            FillupData.Load(reder);
            ProductModel Fillupmodel = new ProductModel();
            foreach (DataRow dataModel in FillupData.Rows)
            {
                Fillupmodel.ProductID = Convert.ToInt32(dataModel["ProductID"]);
                Fillupmodel.ProductName = dataModel["ProductName"].ToString();
                Fillupmodel.ProductPrice = Convert.ToInt32(dataModel["ProductPrice"]);
                Fillupmodel.ProductCode = (dataModel["ProductCode"]).ToString();
                Fillupmodel.Description = (dataModel["Description"]).ToString();
                Fillupmodel.UserID = Convert.ToInt32(dataModel["UserID"]);

            }
            #endregion
            return View(Fillupmodel);
        }

        public IActionResult SaveData(ProductModel productmodel) {

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

                    if (productmodel.ProductID == null)
                    {
                        cmd.CommandText = "Pr_Product_Insert";
                        Save_or_update = true;
                    }
                    else
                    {
                        cmd.CommandText = "PR_Product_UpdateByPK";
                        cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = productmodel.ProductID;
                    }
                    cmd.Parameters.Add("@ProductName", SqlDbType.NVarChar).Value = productmodel.ProductName;
                    cmd.Parameters.Add("@ProductPrice", SqlDbType.Decimal).Value = productmodel.ProductPrice;
                    cmd.Parameters.Add("@ProductCode", SqlDbType.NVarChar).Value = productmodel.ProductCode;
                    cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = productmodel.Description;
                    cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = productmodel.UserID;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    TempData["ErrorMessage"] = "An error occurred while saving Product details: " + e.Message;
                    return RedirectToAction("Prodcut");
                }
                if (Save_or_update)
                {
                    TempData["SuccessMessage"] = "Product details have been saved successfully!";
                    return RedirectToAction("AddProduct");
                }
                TempData["SuccessMessage"] = "Product details have been Updated successfully!";
                return RedirectToAction("Prodcut");

            }
        }
        public IActionResult Delete(int ProductID)
        {
            try
            {
                string conStr = configuration.GetConnectionString("ConnectionString");
                SqlConnection connection = new SqlConnection(conStr);
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PR_Product_DeleteByPK";
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = ProductID;
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = "An error occurred while Deleting User details: " + e.Message;
                return RedirectToAction("Prodcut");
            }
            TempData["SuccessMessage"] = "User details have been Deleted successfully!";
            return RedirectToAction("Prodcut");
        }
        public IActionResult AddInController(ProductModel newData) {

            newData.ProductID = products.Count + 1;
            products.Add(newData);
            return View("Prodcut",products);
            }
    }
}
