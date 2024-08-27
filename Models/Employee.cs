using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace mvc.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Key]
        public int EmpId { get; set; }

        [Required]
        public string EmpName { get; set; }

        [Required]
        public string EmpPhone { get; set; }

        [Required]
        public string EmpDept { get; set; }

        [Required]
        public int Number { get; set; }
    }
}