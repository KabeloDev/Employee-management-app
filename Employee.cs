using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_DomainLayer.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Employee ID")]
        public string? EmployeeId { get; set; }

        [DisplayName("First Name")]
        public string? FirstName { get; set; }

        [DisplayName("Last Name")]
        public string? LastName { get; set; }

        [DisplayName("Start Date")]
        public DateTime StartDate { get; set; } = DateTime.Now;
        public bool Active { get; set; }

    }
}
