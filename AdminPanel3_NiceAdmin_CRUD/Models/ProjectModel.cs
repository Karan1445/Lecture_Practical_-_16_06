using System.ComponentModel.DataAnnotations;

namespace AdminPanel3_NiceAdmin_CRUD.Models
{
    public class ProjectModel
    {
        public int projectID { get; set; }
        [Required(ErrorMessage = "This feild is Compulsory")]
        public string projectName { get; set; }
        [Required(ErrorMessage = "This feild is Compulsory")]
        public string startDate {  get; set; }
        [Required(ErrorMessage = "This feild is Compulsory")]

        public string endDate { get; set; }
        [Required(ErrorMessage = "This feild is Compulsory")]
        public decimal budget {  get; set; }
    }
}
