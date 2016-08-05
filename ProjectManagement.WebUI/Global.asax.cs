using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using ProjectManagement.Domain.Entities;
using ProjectManagement.WebUI.Infrastructure;
using ProjectManagement.WebUI.Models;
using ProjectManagement.WebUI.Helpers;

namespace ProjectManagement.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory()); //

            RegisterAutomapper();
        }

        private void RegisterAutomapper()
        {
            Mapper.Initialize(cfg =>
            {

                cfg.CreateMap<User, UserViewModel>();

                cfg.CreateMap<User, UserPageViewModel>()
                    .ForMember(x => x.IsNotification, x => x.MapFrom(m => m.notification));
                cfg.CreateMap<UserPageViewModel, User>()
                    .ForMember(x => x.notification, x => x.MapFrom(m => m.IsNotification));

                cfg.CreateMap<Project, ProjectsViewModel>()
                    .ForMember(x => x.Initiator, x => x.MapFrom(m => m.User.name));

                cfg.CreateMap<ProjectCreateViewModel, Project>();

                cfg.CreateMap<Task, TaskEditViewModel>()
                    .ForMember(x => x.Priority, x => x.MapFrom(m => m.fkPriority)); ;
                cfg.CreateMap<TaskEditViewModel, Task>()
                    .ForMember(x => x.fkPriority, x => x.MapFrom(m => m.Priority));

                cfg.CreateMap<Task, TaskViewModel>()
                    .ForMember(x => x.PriorityCssClass,
                        x => x.MapFrom(m => "priority-" +m.TasksPriority.name.ToLower()))
                    .ForMember(x => x.Status, x => x.MapFrom(m => m.TasksStatus.name));

                cfg.CreateMap<TasksStatus, SelectListItem>()
                    .ForMember(x => x.Text, x => x.MapFrom(m => m.name))
                    .ForMember(x => x.Value, x => x.MapFrom(m => m.id));

                cfg.CreateMap<TasksPriority, ClassedSelectListItem>()
                    .ForMember(x => x.Value, x => x.MapFrom(m => m.id))
                    .ForMember(x => x.Text, x => x.MapFrom(m => m.name))
                    .ForMember(x => x.CssClass, x => x.MapFrom(m => "priority-" + m.name.ToLower()));
            });
        }
    }
}
