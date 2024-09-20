namespace AdminPanel3_NiceAdmin_CRUD
{
    public class CommonAccess
    {
       private static HttpContextAccessor htc;
        static CommonAccess() {
            htc = new HttpContextAccessor();
        }

        public static int? UserID() {
            if (htc.HttpContext.Session.GetString("UserID") == null)
            {
                return null;
            }
            else {
                return Convert.ToInt32(htc.HttpContext.Session.GetString("UserID"));
               }
        }
        public static String? UserName()
        {
            if (htc.HttpContext.Session.GetString("UserName") == null)
            {
                return null;
            }
            else
            {
                return htc.HttpContext.Session.GetString("UserName");
            }
        }
    }
}
