using AdminPanel3_NiceAdmin_CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanel3_NiceAdmin_CRUD.Controllers
{
    public class BillsController : Controller
    {
        public static List<BillsModel> bills = new List<BillsModel>() { 
        new BillsModel{ BillId=1,BillNumber="100",BillDate=DateTime.Parse("15-05-2024"),OrderId=123,TotalAmount=150,Discount=20,NetAmount=130,UserID=1},



        };
        public IActionResult Index()
        {
            return View(bills);
        }
        
        public IActionResult AddBills() {

            return View();
        }
        [HttpPost]
        public IActionResult AddDataInController(BillsModel newData)
        {
            newData.BillId = bills.Count + 1;
            bills.Add(newData);
            return View("Index",bills);
        }
    }
}
