using System.ComponentModel.DataAnnotations;

namespace AdminPanel3_NiceAdmin_CRUD.Models
{
    public class StudentModel
    {
        public int StudentID { get; set; }
        [Required(ErrorMessage ="This field is Compulsory")]
        [Display(Name ="Student Name")]
        [DataType(DataType.Text,ErrorMessage ="Please Enter Valid Name!")]
        [MaxLength(100,ErrorMessage ="Student Name is too long!")]
        public string StudentName { get; set; }
        [Required(ErrorMessage ="This Field is compulsory")]
        //[Range(1,100,ErrorMessage ="Range must be in 1-100")]
        [MinLength(12)]
        [MaxLength(24)]
        [Display(Name ="EnrollMent")]
        //[DataType(DataType.Date)]
        public string EnrollMentNo { get; set; }

        [Required(ErrorMessage ="This Field is compulsory!")]
        [Display(Name ="Password")]
        [DataType(DataType.Text,ErrorMessage ="Not Valid Passowrd Type")]
        public string Password { get; set; }

        [Required(ErrorMessage ="This Feild is Compulsary")]
        [MaxLength(30,ErrorMessage ="Max Limit is 30 Numbers")]
        [Display(Name ="Roll Number")]
        public int RollNo{get;set;}

        [Required(ErrorMessage = "This Feild is Compulsary")]
        [MaxLength(2,ErrorMessage ="Not Valid Semester!")]
        [Display(Name ="Current Semester")]
        public int CurrentSemester { get; set; }
        [EmailAddress]
        [Required(ErrorMessage ="This Feild is Compulsary")]

        public string EmailInstitue { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "This Feild is Compulsary")]
        public string EmailPeronal { get; set; }
        [Required(ErrorMessage ="This feild is compulsary")]
        [DataType(DataType.PhoneNumber)]
        public string Contact { get; set; }
        [Required(ErrorMessage = "This feild is compulsary")]
        [MaxLength(30,ErrorMessage ="Max length!!")]
        public int CastID { get; set; }
        [Required(ErrorMessage = "This feild is compulsary")]
        [MaxLength(30, ErrorMessage = "Max length!!")]
        public int CityID { get; set; }
        public string Remarks { get; set; }
    }
}
