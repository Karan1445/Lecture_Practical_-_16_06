using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Components;
namespace AdminPanel3_NiceAdmin_CRUD
{
    public class CheckAccess: ActionFilterAttribute, IAuthorizationFilter
    {
       
        public void OnAuthorization(AuthorizationFilterContext afc) {
            var configure = (IConfiguration)afc.HttpContext.RequestServices.GetService(typeof(IConfiguration));
            string connectionStr = configure.GetConnectionString("ConnectionString");
            SqlConnection connection = new SqlConnection(connectionStr);
            connection.Open();
            SqlCommand cmdFillUpData = connection.CreateCommand();
            cmdFillUpData.CommandText = "PR_User_SelectByPk";
            cmdFillUpData.CommandType = CommandType.StoredProcedure;
            cmdFillUpData.Parameters.Add("@Primary_key", SqlDbType.Int).Value = Convert.ToInt32(afc.HttpContext.Session.GetString("UserID"));
            SqlDataReader reder = cmdFillUpData.ExecuteReader();
            DataTable FillupData = new DataTable();
            FillupData.Load(reder);


            if (afc.HttpContext.Session.GetString("UserID") == null)
            {
                afc.Result = new RedirectResult("~/User/Login");
            }
            else if (!Convert.ToBoolean(FillupData.Rows[0]["IsActive"])) {
                afc.Result = new RedirectResult("~/User/Login");
            }

        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            context.HttpContext.Response.Headers["Expires"] = "-1";
            context.HttpContext.Response.Headers["Pragma"] = "no-cache";
            base.OnResultExecuting(context);
        }
    }
}
