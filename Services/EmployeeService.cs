using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PCSProject.Database;
using PCSProject.Domain;
using PCSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCSProject.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DBContext _context;
        private readonly IMapper _mapper;

        public EmployeeService(DBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> Create(EmployeeRequest request)
        {
            if (request == null)
            {
                return "Parameter is null";
            }

            if (string.IsNullOrEmpty(request.QualificationList))
            {
                return "QualificationList is null";
            }

            var data = new List<Emp_Qualification>();
            request.Emp_QualificationList = JsonConvert.DeserializeObject<List<Emp_Qualification>>(request.QualificationList);

            var employee = new Employee()
            {
                Emp_Name = request.Emp_Name,
                Salary = (decimal)request.Salary,
                DOB = request.DOB,
                Gender = request.Gender,
                Entry_By = "Admin",
                Entry_Date = DateTime.Now,
            };
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();

            var Employee_Id = await _context.Employees.OrderByDescending(p => p.Employee_Id).Select(p => p.Employee_Id)?.FirstOrDefaultAsync();
            if (request.Emp_QualificationList.Count > 0)
            {
                foreach (var item in request.Emp_QualificationList)
                {
                    var empQualification = new Emp_Qualification()
                    {
                        Employee_Id = Employee_Id,
                        Q_Id = item.Q_Id,
                        Marks = item.Marks
                    };
                    data.Add(empQualification);
                }
            }
            await _context.Emp_Qualifications.AddRangeAsync(data);
            await _context.SaveChangesAsync();
            return "Success";
        }



        public async Task<string> Update(EmployeeRequest request)
        {
            if (request == null)
            {
                return "Parameter is null";
            }

            if (string.IsNullOrEmpty(request.QualificationList))
            {
                return "QualificationList is null";
            }

            var data = new List<Emp_Qualification>();
            request.Emp_QualificationList = JsonConvert.DeserializeObject<List<Emp_Qualification>>(request.QualificationList);
            var employeeData = await _context.Employees.AsNoTracking().Where(p => p.Employee_Id == request.Employee_Id).FirstOrDefaultAsync();

            var employee = new Employee()
            {
                Employee_Id = employeeData.Employee_Id,
                Emp_Name = request.Emp_Name,
                Salary = (decimal)request.Salary,
                DOB = request.DOB,
                Gender = request.Gender,
                Entry_By = "Admin",
                Entry_Date = DateTime.Now,
            };
            employeeData = employee;
            _context.Employees.Update(employeeData);
            await _context.SaveChangesAsync();

            var Employee_Id = await _context.Employees.OrderByDescending(p => p.Employee_Id).Select(p => p.Employee_Id)?.FirstOrDefaultAsync();
            if (request.Emp_QualificationList.Count > 0)
            {
                foreach (var item in request.Emp_QualificationList)
                {
                    var isExist = _context.Emp_Qualifications.Any(p => p.Q_Id == item.Q_Id && p.Employee_Id == request.Employee_Id);
                    if (isExist)
                    {
                        var empQualification = new Emp_Qualification()
                        {
                            Employee_Id = Employee_Id,
                            Q_Id = item.Q_Id,
                            Marks = item.Marks
                        };
                        data.Add(empQualification);
                    }
                }
            }
            _context.Emp_Qualifications.UpdateRange(data);
            await _context.SaveChangesAsync();
            return "Success";
        }

        public async Task<IList<Employee>> EmployeeList()
        {
            var list = await _context.Employees.ToListAsync();
            if (list.Count > 0)
            {
                return list;
            }
            return new List<Employee>();
        }
        public async Task<IList<QualificationList>> QualificationList()
        {
            var list = await _context.QualificationLists.ToListAsync();
            if (list.Count > 0)
            {
                return list;
            }
            return new List<QualificationList>();
        }

        public async Task<Emp_QualificationListModel> EmpQualificationList(int EmployeeId)
        {
            var models = new Emp_QualificationListModel();
            if (models == null)
                models = new Emp_QualificationListModel();

            var empQualificationList = await _context.Emp_Qualifications.Where(p => p.Employee_Id == EmployeeId).ToListAsync();
            if (empQualificationList.Count > 0)
            {
                foreach (var emp in empQualificationList)
                {
                    var item = await PrepareEmpQualificationModelAsync(null, emp);
                    models.employeeQualification.Add(item);
                }
            }
            models.employee = await _context.Employees.FirstOrDefaultAsync(p => p.Employee_Id == EmployeeId);
            return await Task.FromResult(models);
        }

        public async Task<Emp_QualificationModel> PrepareEmpQualificationModelAsync(Emp_QualificationModel model, Emp_Qualification empQualification)
        {
            model = _mapper.Map<Emp_QualificationModel>(empQualification);
            model.Q_Name = await _context.QualificationLists.Where(p => p.Q_Id == model.Q_Id).Select(p => p.Q_Name).FirstOrDefaultAsync();
            return await Task.FromResult(model);
        }
    }
}
