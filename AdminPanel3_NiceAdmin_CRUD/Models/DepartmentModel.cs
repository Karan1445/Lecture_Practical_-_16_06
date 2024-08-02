using System.ComponentModel.DataAnnotations;

namespace AdminPanel3_NiceAdmin_CRUD.Models
{
    public class DepartmentModel
    {
        public int departmentID { get; set; }
        [Required(ErrorMessage ="This Feild is Compulsory")]
        public string departmentName { get; set; }
    }
}
