using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.CarCatalog.Services.Models.Car
{
    public class CarQueryModel
    {
        [JsonIgnore]
        public String Brand { get; set; }
        public String Name { get; set; }
        public String Color { get; set; }
        public int Year { get; set; }
    }
}
