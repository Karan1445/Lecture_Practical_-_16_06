using AdminPanel3_NiceAdmin_CRUD.Models;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Prodcut()
        {

            return View(products);
        }
        public IActionResult AddProduct() {
            return View();
        }
        public IActionResult AddInController(ProductModel newData) {

            newData.ProductID = products.Count + 1;
            products.Add(newData);
            return View("Prodcut",products);
            }
    }
}
