using CarShop.ViewModels.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services.Contracts
{
    public interface ICarService
    {
        ICollection<string> CreateCar(CarFormViewModel model, string userId);

        ICollection<CarAllViewModel> GetAllCars(string userId);

        bool IsUserMechanic(string userId);
        
        bool IsOwnsCar(string userId, string carId);
    }
}
