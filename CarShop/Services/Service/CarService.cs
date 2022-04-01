using CarShop.Data;
using CarShop.Data.Model;
using CarShop.Services.Contracts;
using CarShop.ViewModels.Cars;
using System.Collections.Generic;
using System.Linq;

namespace CarShop.Services.Service
{
    public class CarService : DBaseService<Car>, ICarService
    {
        private readonly IUserService users;
        private readonly IValidatorService validator;

        public CarService(ApplicationDbContext data, 
               IValidatorService carValidator, 
               IUserService userService) 
            : base(data)
        {
            users = userService;
            validator = carValidator;
        }

        public ICollection<string> CreateCar(CarFormViewModel model, string userId)
        {
            var errors = validator.ValidateModel(model).ToList();

            if (errors.Any())
            {
                return errors;
            }

            var car = new Car
            {
                Model = model.Model,
                Year = model.Year,
                PictureUrl = model.Image,
                PlateNumber = model.PlateNumber,
                OwnerId = userId
            };
            ;
            db.Add(car);
            db.SaveChanges();

            return errors;
        }

        public ICollection<CarAllViewModel> GetAllCars(string userId)
        {
            var allCars = All();

            var isUserMechanic = users.IsMechanic(userId);

            if (isUserMechanic)
            {
                allCars = allCars.Where(i => i.Issues.Any(i => i.IsFixed == false));
            }
            else
            {
                allCars = allCars.Where(c => c.OwnerId == userId);
            }

            var cars = allCars.Select(c => new CarAllViewModel
            {
                Id = c.Id,
                Model = c.Model,
                Image = c.PictureUrl,
                PlateNumber = c.PlateNumber,
                Year = c.Year,
                FixedIssues = c.Issues.Count(i => i.IsFixed),
                RemainingIssues = c.Issues.Count(i => i.IsFixed == false)
            })
            .ToList();

            return cars;
        }

        public bool IsUserMechanic(string userId)
        {
            return users.IsMechanic(userId);
        }

        public bool IsOwnsCar (string userId, string carId)
        {
            return db.Cars.Any(c => c.Id == carId && c.OwnerId == userId);
        }
    }
}
