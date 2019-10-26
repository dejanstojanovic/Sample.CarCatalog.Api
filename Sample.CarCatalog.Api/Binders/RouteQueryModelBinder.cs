using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Sample.CarCatalog.Services.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.CarCatalog.Api.Binders
{
    public class RouteQueryModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            //Create model instance
            var model = Activator.CreateInstance(bindingContext.ModelMetadata.ModelType);

            //Bind matching values from the 
            foreach (var keyValue in bindingContext.ActionContext.HttpContext.Request.Query)
            {
                SetPropertyValue(model, keyValue.Key, keyValue.Value.FirstOrDefault());
            }

            //Bind matching value from the route
            foreach (var routeValue in bindingContext.ActionContext.RouteData.Values)
            {
                SetPropertyValue(model, routeValue.Key, routeValue.Value);
            }


            //Return the model
            bindingContext.Result = ModelBindingResult.Success(model);
            return Task.CompletedTask;
        }

        private void SetPropertyValue(Object model, String name, Object value)
        {
            var prop = model.GetType().GetProperties().SingleOrDefault(p => p.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));
            if (prop != null)
            {
                var typedValue = Convert.ChangeType(value, prop.PropertyType);
                prop.SetValue(model, typedValue);
            }
        }

    }
}
