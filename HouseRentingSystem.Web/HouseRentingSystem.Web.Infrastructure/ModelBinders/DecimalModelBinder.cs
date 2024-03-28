using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;

namespace HouseRentingSystem.Web.Infrastructure.ModelBinders
{
    public class DecimalModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext? bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            ValueProviderResult valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);
            if (valueResult != ValueProviderResult.None && !string.IsNullOrWhiteSpace(valueResult.FirstValue))
            {
                decimal parcedValue = 0m;
                bool binderSucceded = false;

                try
                {
                    string formDecimalValue = valueResult.FirstValue;
                    formDecimalValue = formDecimalValue.Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                    formDecimalValue = formDecimalValue.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                    
                    parcedValue = Convert.ToDecimal(formDecimalValue);
                    binderSucceded = true;
                }
                catch (FormatException fe)
                {
                    bindingContext.ModelState.AddModelError(bindingContext.ModelName, fe, bindingContext.ModelMetadata);
                }

                if (binderSucceded)
                {
                    bindingContext.Result = ModelBindingResult.Success(parcedValue);
                }
            }
            return Task.CompletedTask;
        }
    }
}
