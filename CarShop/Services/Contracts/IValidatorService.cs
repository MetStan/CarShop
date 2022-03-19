using System.Collections.Generic;

namespace CarShop.Services.Contracts
{
    public interface IValidatorService
    {
        ICollection<string> ValidateModel(object model);
    }
}
