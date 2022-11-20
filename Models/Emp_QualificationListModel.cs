using PCSProject.Domain;
using System.Collections.Generic;

namespace PCSProject.Models
{
    public class Emp_QualificationListModel
    {
        public Employee employee { get; set; }
        public IList<Emp_QualificationModel> employeeQualification { get; set; }

        public Emp_QualificationListModel()
        {
            employeeQualification = new List<Emp_QualificationModel>();
            employee = new Employee();
        }
    }
}
