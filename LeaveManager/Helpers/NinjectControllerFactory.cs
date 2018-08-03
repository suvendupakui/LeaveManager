using Ninject;
using Ninject.Extensions.Xml;
using LeaveMgr.Common.Contracts;
using LeaveMgr.Configurations.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace LeaveManager.Helpers
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private static IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null
                       ? null
                       : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            ninjectKernel.Load(System.Configuration.ConfigurationManager.AppSettings["DIXMLPath"]);
             
        }

        public IKernel GetNinjectKernel()
        {
            return ninjectKernel;
        }
    }
}