using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Moq;
using Ninject;
using Domain.Abstract;
using Domain.Entities;
using Domain.Concrete;



namespace WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBilings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBilings()
        {
            kernel.Bind<IGameRepository>().To<EFGameRepository>();
        }
    }
}