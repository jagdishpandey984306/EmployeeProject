using AutoMapper;
using PCSProject.Domain;
using PCSProject.Models;

namespace PCSProject
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Emp_Qualification, Emp_QualificationModel>().ReverseMap();
            CreateMap<Emp_Qualification, Emp_QualificationListModel>().ReverseMap();
        }
    }
}
