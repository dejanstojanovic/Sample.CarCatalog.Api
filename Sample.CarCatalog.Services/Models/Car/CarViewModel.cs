using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.CarCatalog.Services.Models.Car
{
    public class CarViewModel
    {
        public String Brand { get; set; }
        public String Name { get; set; }
        public String Color { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public bool Availabe { get; set; }
    }
}
