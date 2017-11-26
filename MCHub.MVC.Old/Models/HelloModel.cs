using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCHub.MVC.Models
{
    public class HelloModel
    {

        public static List<Car> GetCars()
        {
            List<Car> cars = new List<Car> {
                new Car {id = 1, Make = "Nissan", Model = "Sentra" },
                new Car {id = 2, Make = "Ford", Model = "Mustang" },
                new Car {id = 1, Make = "Honda", Model = "Civic" }

            };

            return cars;
        }
    }


    public class Car
    {
        public int id { get; set;}
        public string Make { get; set; }
        public string Model { get; set; }


    }
}