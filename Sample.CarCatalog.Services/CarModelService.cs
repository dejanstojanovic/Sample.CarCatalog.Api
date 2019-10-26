using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Sample.CarCatalog.Services.Models.Car;

namespace Sample.CarCatalog.Services
{
    public class CarModelService : ICarModelsService
    {
        public Task<IEnumerable<CarViewModel>> FindModels(CarQueryModel query)
        {
            return Task.FromResult<IEnumerable<CarViewModel>>(new List<CarViewModel> {
            new CarViewModel
            {
                Brand= query.Brand,
                Color=query.Color,
                Name = $"{query.Brand} {query.Name} 1.6",
                Price = 4034,
                Availabe = true,
                Year = query.Year
            }
            });
        }
    }
}
