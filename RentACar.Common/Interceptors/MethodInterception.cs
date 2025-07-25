using Castle.DynamicProxy;

namespace RentACar.Common.Interceptors
{
    public class  MethodInterception : MethodInterceptorBaseAttribute
    {
        protected virtual void OnBefore(IInvocation ınvocation)
        {

        }
        protected virtual void OnAfter(IInvocation ınvocation)
        {

        }
        protected virtual void OnException(IInvocation ınvocation, Exception exception)
        {

        }
        protected virtual void OnSuccess(IInvocation ınvocation)
        {

        }

        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);

            // Əgər validation və ya başqa AOP metodu invocation.ReturnValue təyin edibsə, davam etmə
            if (invocation.ReturnValue != null)
            {
                return;
            }

            try
            {
                invocation.Proceed();
            }
            catch (Exception exception)
            {
                isSuccess = false;
                OnException(invocation, exception);

                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }

            }
            OnAfter(invocation);
        }
    }

}
