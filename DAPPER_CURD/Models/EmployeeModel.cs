using System;
using System.ComponentModel.DataAnnotations;

namespace DAPPER_CURD.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Age is required!")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Salary is required!")]
        public int Salary { get; set; }
        [Required(ErrorMessage = "Position is required!")]
        public string Position { get; set; }
        [Required(ErrorMessage = "Department is required!")]
        public string Department { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
