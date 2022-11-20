using PCSProject.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PCSProject.Models
{
    public class Emp_QualificationModel
    {
        public int EmpQuId { get; set; }
        public int Employee_Id { get; set; }
        public int Q_Id { get; set; }
        public string Q_Name { get; set; }
        public decimal Marks { get; set; }
    }
}
