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
            List<Models.Car> cars = cDB.Cars.ToList();
            JObject jCars = new JObject();
            jCars["Count"] = cars.Count;
            JArray temp = new JArray();
            foreach(Models.Car car in cars)
            {
                JObject jCar = new JObject();
                jCar["Id"] = car.Id;
                jCar["Make"] = car.Make;
                jCar["Model"] = car.Model;
                jCar["Year"] = car.year;
                jCar["Color"] = car.color;
                temp.Add(jCar);
            }
            jCars["Cars"] = temp;

            //JObject jObject = new JObject();
            //jObject["Hello"] = "Test";
            //jObject["Test"] = "Hello";
            //JArray temp = new JArray();
            //jObject["Hmm"] = new JArray();

            
            //jObject["Hmm"][0] = "Test";

            return jCars;
        }
        [HttpGet]
        public JObject GetCar(int Id)
        {
            Models.Car car = cDB.Cars.Find(Id);
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
    }
}
