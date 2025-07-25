using Castle.DynamicProxy;
using FluentValidation;
using RentACar.Common.CrossCuttingConcerns.Validation;
using RentACar.Common.Exceptions;
using RentACar.Common.Interceptors;
using RentACar.Common.Utilities.Results.Concrete;

namespace RentACar.Common.Aspects.ValidationAspect
{
    public class ValidationAspect : MethodInterception
    {
        private readonly Type _validatorType;

        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception("this class don't validation class");
            }
            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var validator = Activator.CreateInstance(_validatorType) as IValidator;
            var entityType = _validatorType.BaseType!.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(c => c.GetType() == entityType);
            foreach (var entity in entities)
            {
                var result = ValidationTool.Validate(validator!, entity);

                if (result != null)
                {
                    invocation.ReturnValue = Task.FromResult(result);
                    return;
                }
            }
        }
    }
}
