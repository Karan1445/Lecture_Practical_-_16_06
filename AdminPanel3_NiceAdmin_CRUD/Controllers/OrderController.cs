using AdminPanel3_NiceAdmin_CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanel3_NiceAdmin_CRUD.Controllers
{
    public class OrderController : Controller
    {
        public static List<OrderModel> order = new List<OrderModel>() {
        new OrderModel{OrderID=1,OrderDate=DateTime.Now,CustomerId=1,PaymentMode="upi",TotalAmount=120.22,ShippingAddress="Rajkot",UserID=1},
        new OrderModel{OrderID=1,OrderDate=DateTime.Now,CustomerId=1,PaymentMode="upi",TotalAmount=120.22,ShippingAddress="Rajkot",UserID=1},
        new OrderModel{OrderID=1,OrderDate=DateTime.Now,CustomerId=1,PaymentMode="upi",TotalAmount=120.22,ShippingAddress="Rajkot",UserID=1},
        new OrderModel{OrderID=1,OrderDate=DateTime.Now,CustomerId=1,PaymentMode="upi",TotalAmount=120.22,ShippingAddress="Rajkot",UserID=1},
        new OrderModel{OrderID=1,OrderDate=DateTime.Now,CustomerId=1,PaymentMode="upi",TotalAmount=120.22,ShippingAddress="Rajkot",UserID=1},





        };
        public IActionResult Order()
        {
            return View(order);
        }
        public IActionResult AddOrder() {
            return View();
        }
        public IActionResult AddInController(OrderModel newData) {
            newData.OrderID = order.Count + 1;
            order.Add(newData);
            return View("Order", order);
            }
    }
}
