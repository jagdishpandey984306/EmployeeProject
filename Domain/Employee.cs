using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCSProject.Domain
{
    [Table("Employee")]
    public class Employee
    {
        public Employee()
        {
            Emp_Qualifications = new HashSet<Emp_Qualification>();
        }

        [Key]
        public int Employee_Id { get; set; }

        [Display(Name ="Name*")]
        [StringLength(50)]
        [Required(ErrorMessage = "*Name is required")]
        public string Emp_Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "DOB is required")]
        [Display(Name = "DOB*")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime DOB { get; set; }

        [Display(Name = "Gender*")]
        [StringLength(10)]
        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; } = string.Empty;
        [Display(Name = "Salary")]
        public decimal? Salary { get; set; }
        [StringLength(100)]
        public string Entry_By { get; set; } = string.Empty;
        public DateTime Entry_Date { get; set; }

        [InverseProperty(nameof(Emp_Qualification.Employee))]
        public virtual ICollection<Emp_Qualification> Emp_Qualifications { get; set; }
    }
}
