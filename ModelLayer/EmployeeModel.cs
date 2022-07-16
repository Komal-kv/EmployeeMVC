using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelLayer
{
    public class EmployeeModel
    {
        [Key]
        public int EmployeeId { get; set; } 
        public string Name { get; set; }
        public string ProfileImage { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        [Range (0, 500000)]
        public long Salary { get; set; }
        public DateTime StartDate { get; set; }
        public string Notes { get; set; }
    }
}
