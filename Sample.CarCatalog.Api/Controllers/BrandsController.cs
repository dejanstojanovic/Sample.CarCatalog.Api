using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sample.CarCatalog.Api.Binders;
using Sample.CarCatalog.Services;
using Sample.CarCatalog.Services.Models;
using Sample.CarCatalog.Services.Models.Car;

namespace Sample.CarCatalog.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        readonly ICarModelsService _carModelsService;

        public BrandsController(ICarModelsService carModelsService)
        {
            _carModelsService = carModelsService;
        }

        [HttpGet("{brand}/models")]
        public async Task<ActionResult<IEnumerable<CarViewModel>>> Get(
            [FromQuery, ModelBinder(typeof(RouteQueryModelBinder))] CarQueryModel query
            )
        {
            return Ok(await _carModelsService.FindModels(query));
        }
    }
}
