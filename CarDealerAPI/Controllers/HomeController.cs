using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CarDealerAPI.Controllers
{
    public class HomeController : Controller
    {
        private int port = 64332;
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult GetCars()
        {
            //Models.GCCarDealerShipEntities gcDB = new Models.GCCarDealerShipEntities();
            UriBuilder ApiUri = new UriBuilder();
            ApiUri.Host = "localhost";
            ApiUri.Path = "api/Car/GetAllCars";
            ApiUri.Port = port;
            HttpWebRequest request = WebRequest.CreateHttp(ApiUri.ToString());
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream());
            string data = sr.ReadToEnd();
            sr.Close();
                
            List<Models.Car> cars = new List<Models.Car>();
            JObject jcars = JObject.Parse(data);
            foreach(JToken temp in jcars["Cars"])
            {
                Models.Car car = new Models.Car();
                car.Id = temp["Id"].Value<int>();
                car.Make = temp["Make"].Value<string>();
                car.Model = temp["Model"].Value<string>();
                car.year = temp["Year"].Value<int>();
                car.color = temp["Color"].Value<string>();
                cars.Add(car);
            }
            return View(cars);
        }
        public ActionResult GetCarsBy(string Make ,string Model , int? Year , string Color )
        {
            UriBuilder ApiUri = new UriBuilder();
            ApiUri.Host = "localhost";
            ApiUri.Path = "api/Car/GetAllCars";
            ApiUri.Query = $"make={Make}&model={Model}&year={Year}&color={Color}";
            ApiUri.Port = port;
            HttpWebRequest request = WebRequest.CreateHttp(ApiUri.ToString());
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream());
            string data = sr.ReadToEnd();
            sr.Close();
            
            List<Models.Car> cars = new List<Models.Car>();
            JObject jcars = JObject.Parse(data);
            foreach (JToken temp in jcars["Cars"])
            {
                Models.Car car = new Models.Car();
                car.Id = temp["Id"].Value<int>();
                car.Make = temp["Make"].Value<string>();
                car.Model = temp["Model"].Value<string>();
                car.year = temp["Year"].Value<int>();
                car.color = temp["Color"].Value<string>();
                cars.Add(car);
            }
            ViewBag.Make = Make;
            ViewBag.Model = Model;
            ViewBag.Year = Year;
            ViewBag.Color = Color;

            return View("GetCars",cars);
        }
    }
}
