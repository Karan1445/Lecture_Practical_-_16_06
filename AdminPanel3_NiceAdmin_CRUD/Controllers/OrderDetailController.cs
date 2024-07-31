using AdminPanel3_NiceAdmin_CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanel3_NiceAdmin_CRUD.Controllers
{
    public class OrderDetailController : Controller
    {
        public static List<OrderDetailModel> orderDetails = new List<OrderDetailModel>() {
        new OrderDetailModel{OrderID=1,OrderDetailID=1,ProductID=1,Quantity=10,Amount=120,TotaAmount=1200,UserID=1 }
        };
        public IActionResult orderDetail()
        {
            return View(orderDetails);
        }
        public IActionResult AddOrderDetail() {
            return View();
        }
        public IActionResult AddInController(OrderDetailModel newData) {
            newData.OrderDetailID = orderDetails.Count + 1;
            orderDetails.Add(newData);
            return View("orderDetail",orderDetails);
        }
    }
}
