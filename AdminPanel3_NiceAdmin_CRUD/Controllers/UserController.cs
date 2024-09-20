using AdminPanel3_NiceAdmin_CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace AdminPanel3_NiceAdmin_CRUD.Controllers
{
    
    public class UserController : Controller
    {
        #region extra data
        public static List<UserModel> user = new List<UserModel>() { 
        new UserModel{UserID=1,UserName="Karan",Email="goheljitu164@gmail.com",Password="Karan@1234",MobileNo="8141953822",Address="Rajkot",IsActive=true },


        new UserModel{UserID=2,UserName="Parth",Email="Path@gmail.com",Password="Parth@1234",MobileNo="89899899",Address="Kokidia",IsActive=true },
        new UserModel{UserID=3,UserName="Harsh",Email="harsh@gmail.com",Password="harsh@1234",MobileNo="252515565",Address="sapar",IsActive=true },
        };
        #endregion
        public IConfiguration configuration;
        public UserController(IConfiguration config) {
            configuration = config;
            }
        #region index
        [CheckAccess]
        public IActionResult User()
        {
            string sqlconnectionstring = this.configuration.GetConnectionString("ConnectionString");
            SqlConnection connection = new SqlConnection(sqlconnectionstring);
            connection.Open();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "PR_User_SelectAll";
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            return View(dt);
        }
        #endregion
        #region delete
        [CheckAccess]
        public IActionResult Delete(int UserID)
        {
            try
            {
                string conStr = configuration.GetConnectionString("ConnectionString");
                SqlConnection connection = new SqlConnection(conStr);
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PR_User_DeleteByPK";
                cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserID;
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = "An error occurred while Deleting User details: " + e.Message;
                return RedirectToAction("User");
            }
            TempData["SuccessMessage"] = "User details have been Deleted successfully!";
            return RedirectToAction("User");
        }
        #endregion
        #region add/edit user
        [CheckAccess]
        public IActionResult AddUser(int UserID) {

            string connectionStr = configuration.GetConnectionString("ConnectionString");
            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();
            SqlCommand cmdFillUpData = connection.CreateCommand();
            cmdFillUpData.CommandText = "PR_User_SelectByPk";
            cmdFillUpData.CommandType = CommandType.StoredProcedure;
            cmdFillUpData.Parameters.Add("@Primary_key", SqlDbType.Int).Value = UserID;
            SqlDataReader reder = cmdFillUpData.ExecuteReader();
            DataTable FillupData = new DataTable();
            FillupData.Load(reder);
            UserModel Fillupmodel = new UserModel();
            foreach (DataRow dataModel in FillupData.Rows)
            {
                Fillupmodel.UserID = Convert.ToInt32(dataModel["UserID"]);
                Fillupmodel.UserName = Convert.ToString(dataModel["UserName"]);
                Fillupmodel.Password = Convert.ToString(dataModel["Password"]);
                Fillupmodel.Email = Convert.ToString(dataModel["Email"]);
                Fillupmodel.MobileNo = Convert.ToString(dataModel["MobileNo"]);
                Fillupmodel.Address = Convert.ToString(dataModel["Address"]);
                Fillupmodel.IsActive = Convert.ToBoolean(dataModel["IsActive"]);

            }
            return View(Fillupmodel);
            
        }
        #endregion
        #region Extra data
        [CheckAccess]
        public IActionResult AddInContoller(UserModel newData) {
            newData.UserID = user.Count + 1;
            user.Add(newData);
            return View("User",user);
        }
        #endregion
        #region save/update data
        [CheckAccess]
        public IActionResult SaveData(UserModel usermodel) {

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

                    if (usermodel.UserID == null)
                    {
                        cmd.CommandText = "Pr_User_Insert";
                        Save_or_update = true;
                    }
                    else
                    {
                        cmd.CommandText = "PR_User_UpdateByPK";
                        cmd.Parameters.Add("@UseriD", SqlDbType.Int).Value = usermodel.UserID;
                    }
                    cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = usermodel.UserName;
                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = usermodel.Email;
                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = usermodel.Password;
                    cmd.Parameters.Add("@MobileNo", SqlDbType.NVarChar).Value = usermodel.MobileNo;
                    cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = usermodel.Address;
                    cmd.Parameters.Add("@IsActive", SqlDbType.Decimal).Value = usermodel.IsActive;
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    TempData["ErrorMessage"] = "An error occurred while saving/update User details: " + e.Message;
                    return RedirectToAction("User");
                }
                if (Save_or_update)
                {
                    TempData["SuccessMessage"] = "User details have been saved successfully!";
                    return RedirectToAction("AddUser");
                }
                TempData["SuccessMessage"] = "User details have been Updated successfully!";
                return RedirectToAction("User");

            }
        }
        #endregion 
        public IActionResult Login() {
            return View();
        }
        public IActionResult LoginCheck(UserLogin userlogin) {
            
            String sqlconnectionString = this.configuration.GetConnectionString("ConnectionString");
            SqlConnection sqlconnection = new SqlConnection(sqlconnectionString);
            sqlconnection.Open();

            SqlCommand cmd = sqlconnection.CreateCommand();
            cmd.CommandText = "pr_user_login";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = userlogin.UserName;
            cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = userlogin.Password;
            SqlDataReader reder = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reder);
            if (dt == null || dt.Rows.Count < 1)
            {
                TempData["message"] = "No UserFound With This UserName";
            }
         
            else
            {
                
                HttpContext.Session.SetString("UserName", dt.Rows[0]["UserName"].ToString());
                HttpContext.Session.SetString("UserID",Convert.ToString(dt.Rows[0]["UserID"]));
                 
                
                return RedirectToAction("Index","Home");
            }

            TempData["message"] = "User is Temporary Inactive Or PassWord is Incorrect";
            return View("Login");
        }
        public IActionResult Logout()
        {
            HttpContext.Response.Clear();
            HttpContext.Response.Cookies.Delete(".AspNetCore.Session");
            return RedirectToAction("Index","Home");
        }
        public IActionResult Register() {
            return View();
        }
        public IActionResult RegisterUser(UserModel usermodel) {
            try
            {
                String sqlConnectionString = this.configuration.GetConnectionString("ConnectionString");
                SqlConnection conneciton = new SqlConnection(sqlConnectionString);
                conneciton.Open();
                SqlCommand cmd = conneciton.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Pr_User_Insert";
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = usermodel.UserName;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = usermodel.Email;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = usermodel.Password;
                cmd.Parameters.Add("@MobileNo", SqlDbType.NVarChar).Value = usermodel.MobileNo;
                cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = usermodel.Address;
                cmd.Parameters.Add("@IsActive", SqlDbType.Bit).Value = true;
                cmd.ExecuteNonQuery();
                HttpContext.Session.SetString("UserName", usermodel.UserName.ToString());
                HttpContext.Session.SetString("UserID", Convert.ToString(usermodel.UserID));
            }
            catch (Exception e) {
                TempData["message"] = "There is Error While Creating the User. "+e.Message;
                return View("Login");
            }
            return RedirectToAction("Index", "Home");
        }

    }
}
