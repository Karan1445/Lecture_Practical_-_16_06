using AdminPanel3_NiceAdmin_CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanel3_NiceAdmin_CRUD.Controllers
{
    public class CustomerController : Controller
    {
        public static List<CustomerModel> customers = new List<CustomerModel>()
        {
         new CustomerModel{ CustomerID=1,CustomerName="karan",HomeAddress="Rajkot",Email="goheljitu164@gmail.com",MobileNo="8141953822",GST_NO="124555sd5455",CityName="Rajkot",PinCode="360003",NetAmount=150,UserID=1},
        };
        public IActionResult Index()
        {
            return View(customers);
        }
        public IActionResult AddCustomer() {
            return View();
        }
        public IActionResult AddInCustomer(CustomerModel newData) {
            newData.CustomerID = customers.Count + 1;
            customers.Add(newData);
            return View("Index",customers);
        }
    }
}
