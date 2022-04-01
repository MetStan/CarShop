using System.ComponentModel.DataAnnotations;
using static CarShop.Data.DataConstants;

namespace CarShop.ViewModels.Cars
{
    public class CarFormViewModel
    {
        [StringLength(ModelNameMaxLength, MinimumLength = ModelNameMinLength, ErrorMessage = "{0} must be between {2} and {1} characters.")]
        public string Model { get; init; }
                
        public int Year { get; init; }

        [MaxLength(PictureUrlMaxLength, ErrorMessage = "Image address must be less than {1} characters.")]
        public string Image { get; init; }

       
        [RegularExpression(PlateNumberRegularExpression, ErrorMessage = "Plate Number must be in format 'XX0000XX'.")]
        public string PlateNumber { get; init; }
    }
}
