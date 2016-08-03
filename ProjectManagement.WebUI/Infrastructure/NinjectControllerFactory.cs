using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using ProjectManagement.Domain.Abstract;
using ProjectManagement.Domain.Concrete;
using ProjectManagement.WebUI.Infrastructure.Abstract;
using ProjectManagement.WebUI.Infrastructure.Concrete;

namespace ProjectManagement.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            // init container
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            // get controller object from container by type
            return controllerType == null
              ? null
              : (IController)ninjectKernel.Get(controllerType);
        }
        private void AddBindings()
        {
            // configure container
            ninjectKernel.Bind<IDataRepository>().To<EFDataRepository>();
            ninjectKernel.Bind<IUserRepository>().To<UserRepository>();
            ninjectKernel.Bind<IProjectRepository>().To<ProjectRepository>();
            ninjectKernel.Bind<ITaskRepository>().To<TaskRepository>();
            ninjectKernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
            ninjectKernel.Bind<IResetPass>().To<PMResetPass>();
        }
    }
}