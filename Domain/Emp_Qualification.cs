using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCSProject.Domain
{
    [Table("Emp_Qualification")]
    public class Emp_Qualification
    {
        [Key]
        public int EmpQuId { get; set; }
        public int Employee_Id { get; set; }
        public int Q_Id { get; set; }
        public decimal Marks { get; set; }

       
        [ForeignKey(nameof(Employee_Id))]
        [InverseProperty("Emp_Qualifications")]
        public virtual Employee Employee { get; set; }

       
        [ForeignKey(nameof(Q_Id))]
        [InverseProperty("Emp_Qualifications")]
        public virtual QualificationList QualificationList { get; set; }
    }
}
