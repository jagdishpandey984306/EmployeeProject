using PCSProject.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PCSProject.Models
{
    public class EmployeeRequest
    {
        public int Employee_Id { get; set; }

        [Display(Name = "Name*")]
        [Required(ErrorMessage = "*Name is required")]
        public string Emp_Name { get; set; } = string.Empty;

        [Display(Name = "DOB*")]
        [Required(ErrorMessage = "*DOB is required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime DOB { get; set; }

        [Display(Name = "Gender*")]
        [Required(ErrorMessage = "*Gender is required")]
        public string Gender { get; set; } = string.Empty;

        [Display(Name = "Salary")]
        public decimal? Salary { get; set; }
        public string QualificationList { get; set; }
        public ICollection<Emp_Qualification> Emp_QualificationList { get; set; } = new List<Emp_Qualification>();
    }
}
