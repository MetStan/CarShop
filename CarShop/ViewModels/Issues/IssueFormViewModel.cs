using System.ComponentModel.DataAnnotations;
using static CarShop.Data.DataConstants;

namespace CarShop.ViewModels.Issues
{
    public class IssueFormViewModel
    {
        [MinLength(DescriptionMinLength, ErrorMessage = "{0} shoud be longer than {1} characters.")]
        public string Description { get; init; }

        public string CarId { get; init; }
    }
}
