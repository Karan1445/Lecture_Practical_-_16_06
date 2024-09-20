using AdminPanel3_NiceAdmin_CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
namespace AdminPanel3_NiceAdmin_CRUD.Controllers
{
    [CheckAccess]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Employee()
        {
            var employeeList = new List<EmployeeModel>
        {
            new EmployeeModel
            {
                EmployeeID = 1,
                FirstName = "Parth",
                LastName = "Ladani",
                Email = "parthladani@gmail.com",
                PhoneNumber = "1234567890",
                HireDate = "03/01/2024",
                JobTitle = "Manager",
                Salary = 10000,
                DepartmentID = 3
            },
            new EmployeeModel
            {
                EmployeeID = 2,
                FirstName = "abc",
                LastName = "xyz",
                Email = "abc@gmail.com",
                PhoneNumber = "1234567890",
                HireDate = "05/10/2023",
                JobTitle = "HR",
                Salary = 10000,
                DepartmentID = 6
            }
        };

            return View(employeeList);
        }

        public IActionResult AddEmployee()
        {
            return View();
        }
        public IActionResult Project() 
        {
            var projects = new List<ProjectModel>
            {
                new ProjectModel
                {
                    projectID=1,
                    projectName="GO EVENT",
                    startDate="01/04/2022",
                    endDate="01/04/2023",
                    budget=20000
                },
                new ProjectModel
                {
                    projectID=2,
                    projectName="Expance Tracker",
                    startDate="28/05/2024",
                    endDate="07/06/2024",
                    budget=10000
                }
            };
            return View(projects); 
        }
        public IActionResult AddProject()
        {
            return View();
        }
        public IActionResult Department()
        {
            var departments = new List<DepartmentModel>
            {
                new DepartmentModel
                {
                    departmentID=1,
                    departmentName="CE"
                },
                new DepartmentModel
                {
                    departmentID=2,
                    departmentName="IT"
                }
            };
            return View(departments);
        }
        public IActionResult AddDepartment()
        {
            return View();
        }
        public IActionResult EmployeeProject()
        {
            var empproject = new List<EmployeeProjectModel>
            { 
                new EmployeeProjectModel
                {
                    employeeProjectID=1,
                    employeeID=1,
                    projectID=2
                },
            };
            return View(empproject);
        }
        public IActionResult AddEmployeeProject() { 
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
