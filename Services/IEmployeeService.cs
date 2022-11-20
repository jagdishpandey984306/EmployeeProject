using PCSProject.Domain;
using PCSProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PCSProject.Services
{
    public interface IEmployeeService
    {
        Task<string> Create(EmployeeRequest request);
        Task<string> Update(EmployeeRequest request);
        Task<IList<Employee>> EmployeeList();
        Task<IList<QualificationList>> QualificationList();
        Task<Emp_QualificationListModel> EmpQualificationList(int EmployeeId);

    }
}
