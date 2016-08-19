using IEJPApps.Models;
using IEJPApps.ViewModels;

namespace IEJPApps
{
    internal static class AutoMapperConfig
    {
        public static void Register()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<Project, ProjectLookupViewModel>();
                //config.CreateMap<ProjectLookupViewModel, Project>()
                //    .ForMember(dst => dst.Id, opt => opt.Ignore());

                config.CreateMap<Employee, EmployeeLookupViewModel>();
                //config.CreateMap<EmployeeLookupViewModel, Employee>()
                //    .ForMember(dst => dst.Id, opt => opt.Ignore());

                config.CreateMap<TimeTransaction, TimeTransactionViewModel>()
                    .ForMember(dst => dst.Employee, opt => opt.MapFrom(src => src.Employee))
                    .ForMember(dst => dst.Project, opt => opt.MapFrom(src => src.Project));
                //config.CreateMap<TimeTransactionViewModel, TimeTransaction>()
                //        .ForMember(dst => dst.Id, opt => opt.Ignore());
            });
        }
    }
}