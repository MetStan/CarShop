using CarShop.Data;
using CarShop.Data.Model;
using CarShop.Services.Contracts;
using CarShop.ViewModels.Issues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services.Service
{
    public class IssueService : DBaseService<Issue>, IIssueService
    {
        private readonly IUserService users;
        private readonly ICarService cars;
        private readonly IValidatorService validator;

        public IssueService(ApplicationDbContext data,
               ICarService carService,
               IValidatorService issueValidator,
               IUserService userService)
            : base(data)
        {
            users = userService;
            validator = issueValidator;
            cars = carService;
        }

        public ICollection<string> CreateIssue(IssueFormViewModel model, string carId)
        {
            var errors = validator.ValidateModel(model).ToList();

            if (errors.Any())
            {
                return errors;
            }

            //var car = db.Cars.Where(i => i.Id == carId).FirstOrDefault();

            var issue = new Issue
            {
                CarId = model.CarId,
                Description = model.Description,
            };

            db.Add(issue);
            db.SaveChanges();

            return errors;
        }

        public string DeleteIssue(string carId, string issueId, string userId)
        {
            var error = string.Empty;

            var IsUserMechanic = users.IsMechanic(userId);

            if (IsUserMechanic == false)
            {
                var IsUserOwnsCar = cars.IsOwnsCar(userId, carId);

                if (IsUserOwnsCar == false)
                {
                    return error = "You don't have a permission to Delete Issues!";
                }
            }

            var issue = db.Issues.Find(issueId);

            db.Remove(issue);
            db.SaveChanges();

            return error;
        }

        public string FixIssue(string carId, string issueId, string userId)
        {
            var error = string.Empty;

            var IsUserMechanic = users.IsMechanic(userId);

            if (IsUserMechanic == false)
            {
                return error = "You don't have a permission to Delete Issues!";
            }

            var issue = db.Issues.Find(issueId);
            issue.IsFixed = true;

            db.SaveChanges();

            return error;
        }

        public CarIssueViewModel GetCarIssues(string carId)
        {
            var carIssues = db.Cars
                .Where(c => c.Id == carId)
                .Select(m => new CarIssueViewModel
                {
                    CarId = m.Id,
                    CarModel = m.Model,
                    Year = m.Year,
                    Issues = m.Issues.Select(i => new IssueViewModel
                    {
                        IssueId = i.Id,
                        Description = i.Description,
                        IsFixed = i.IsFixed == true ? "Yes" : "Not Yet"
                    }).ToList()
                })
                .FirstOrDefault();

            return carIssues;
        }
    }
}
