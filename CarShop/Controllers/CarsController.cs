using CarShop.Services.Contracts;
using CarShop.ViewModels.Cars;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System.Collections.Generic;
using System.Linq;

namespace CarShop.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService carService;

        public CarsController(ICarService service)
        {
            this.carService = service;
        }

        [Authorize]
        public HttpResponse All()
        {
            var cars = carService.GetAllCars(User.Id);

            return View(cars);
        }

        [Authorize]
        public HttpResponse Add()
        {
            var isMechanic = carService.IsUserMechanic(User.Id);

            if (isMechanic)
            {
                return Error("Mechanic cannot add cars.");
            }
            return View();
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Add(CarFormViewModel model)
        {
            List<string> errors = carService.CreateCar(model, User.Id).ToList();
            ;
            if (errors.Any() == false)
            {
                return Redirect("/Cars/All");
            }

            return Error(errors);
        }
    }
}
