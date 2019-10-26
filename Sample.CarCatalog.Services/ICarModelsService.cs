using Sample.CarCatalog.Services.Models.Car;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sample.CarCatalog.Services
{
    public interface ICarModelsService
    {
        Task<IEnumerable<CarViewModel>> FindModels(CarQueryModel query);
    }
}
