using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        [Required]
        public string EmployeeName { get; set; }

        [Phone]
        [Required]
        public string PhoneNo { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }

        public string Department { get; set; }


    }
}
