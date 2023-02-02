using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DependecyResolvers.Ninject
{
    public class InstanceFactory
    {
        public static T GetInstance<T>(NinjectModule ninjectModule)
        {
            var kernel = new StandardKernel(ninjectModule);
            return kernel.Get<T>();

        }

        
    }
}
