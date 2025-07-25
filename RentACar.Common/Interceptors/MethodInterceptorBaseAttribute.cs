using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace RentACar.Common.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class MethodInterceptorBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }
        public virtual void Intercept(IInvocation invocation)
        {
        }
    }

}
