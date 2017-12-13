using Core;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EasyScheduleWebClient.Models
{
    public class EmployeeModel
    {
        //public int EmployeeID { get; set; }
        //public string Name { get; set; }
        //public int DepartmentId { get; set; }

        public Employee Employee { get; set; }
        public Department Department { get; set; }



        [DisplayName("Username: ")]
        [Required(ErrorMessage = "This field is required")]
        public string Username { get; set; }


        [Required(ErrorMessage = "This field is required")]
        [DisplayName("Password: ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
