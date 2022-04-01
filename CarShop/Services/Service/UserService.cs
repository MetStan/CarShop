using CarShop.Data;
using CarShop.Data.Model;
using CarShop.Services.Contracts;
using CarShop.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services.Service
{
    public class UserService : DBaseService<User>, IUserService
    {
        private readonly IValidatorService validator;
        private readonly IPasswordHasher hashedPassword;

        public UserService(ApplicationDbContext db,
        IValidatorService userValidator,
        IPasswordHasher passwordHasher)
            : base(db)
        {
            validator = userValidator;
            hashedPassword = passwordHasher;
        }


        public ICollection<string> CreateUser(RegisterFormViewModel model)
        {
            List<string> errors = validator.ValidateModel(model).ToList();

            if (IsUsernameAvailable(model.Username)
                || IsEmailAvailable(model.Email))
            {
                errors.Add($"User or Email exists already.");
            }

            if (errors.Any())
            {
                return errors;
            }

            var user = new User
            {
                Username = model.Username,
                Email = model.Email,
                Password = hashedPassword.HashPassword(model.Password),
                IsMechanic = model.UserType == "Mechanic",
            };

            db.Users.Add(user);
            db.SaveChanges();

            return errors;
        }

        public string GetUserId(LoginFormViewModel model)
        {
            var password = hashedPassword.HashPassword(model.Password);

            var userId = All()
                    .Where(u => u.Username == model.Username && u.Password == password)
                    .Select(u => u.Id)
                    .FirstOrDefault();

            return userId;
        }

        public bool IsEmailAvailable(string email)
        {
            return All().Any(u => u.Email == email);
        }

        public bool IsUsernameAvailable(string username)
        {
            return All().Any(u => u.Username == username);
        }

        public bool IsMechanic (string userId)
        {
            var IsMechanic = All().Any(u => u.Id == userId && u.IsMechanic);
            return IsMechanic;
            ;
        }

    }
}
