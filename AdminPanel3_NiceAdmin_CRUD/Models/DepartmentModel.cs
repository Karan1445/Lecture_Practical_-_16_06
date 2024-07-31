using System.ComponentModel.DataAnnotations;

namespace AdminPanel3_NiceAdmin_CRUD.Models
{
    public class DepartmentModel
    {
        [Required]public int departmentID { get; set; }
        public string departmentName { get; set; }
    }
}
