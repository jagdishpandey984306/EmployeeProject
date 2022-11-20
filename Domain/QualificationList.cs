using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCSProject.Domain
{
    [Table("QualificationList")]
    public class QualificationList
    {
        public QualificationList()
        {
            Emp_Qualifications = new HashSet<Emp_Qualification>();
        }

        [Key]
        public int Q_Id { get; set; }
        [StringLength(150)]
        public string Q_Name { get; set; } = string.Empty;

        [InverseProperty(nameof(Emp_Qualification.QualificationList))]
        public virtual ICollection<Emp_Qualification> Emp_Qualifications { get; set; }
    }
}
