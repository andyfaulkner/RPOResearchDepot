using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Moq;
using System.Web.Mvc;
using Ninject;
using RPOResearchDepot.Domain.Abstract;
using RPOResearchDepot.Domain.Entities;
using RPOResearchDepot.Domain.Concrete;
using RPOResearchDepot.WebUI.Infrastructure.Abstract;
using RPOResearchDepot.WebUI.Infrastructure.Concrete;
using System.Configuration;

namespace RPOResearchDepot.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);  
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<IProductRepository>().To<EFProductRepository>();

            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false")
            };

            kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>().WithConstructorArgument("settings", emailSettings);

            kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }

       
         
    }
}