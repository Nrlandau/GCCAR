using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarDealerAPI.Controllers
{
    public class CarController : ApiController
    {
        Models.GCCarDealerShipEntities cDB = new Models.GCCarDealerShipEntities();
        [HttpGet]
        public JObject GetAllCars()
        {
            return CarsToJson(cDB.Cars.ToList());
        }
        [HttpGet]
        public JObject GetCar(int Id)
        {
            Models.Car car = cDB.Cars.Find(Id);
            return CarToJson(car);
        }
        [HttpGet] 
        public JObject GetAllCars(string make, string model, int? year, string color)
        {

            return CarsToJson(cDB.Cars.Where(x => (make != null ? x.Make == make : true) && 
                                            (model != null ? x.Model == model : true) && 
                                            (year != null ? x.year == year : true) &&
                                            (color != null ? x.color == color : true))
                                            .ToList());
        }
        //How One Car is in JSON
        private JObject CarToJson(Models.Car car)
        {
            JObject jCar = new JObject();
            if (car == null)
            {
                return jCar;
            }
            jCar["Id"] = car.Id;
            jCar["Make"] = car.Make;
            jCar["Model"] = car.Model;
            jCar["Year"] = car.year;
            jCar["Color"] = car.color;
            return jCar;
        }
        //How Multiple Cars are in JSON
        private JObject CarsToJson(IEnumerable<Models.Car> cars)
        {
            JObject jCars = new JObject();
            jCars["Count"] = cars.Count();
            JArray temp = new JArray();
            foreach (Models.Car car in cars)
            {
                temp.Add(CarToJson(car));
            }
            jCars["Cars"] = temp;
            return jCars;

        }
    }
}
