namespace AdminPanel3_NiceAdmin_CRUD.Models
{
    public class EmployeeModel
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string HireDate { get; set; }
        public string JobTitle { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentID { get; set; }

    }
}
