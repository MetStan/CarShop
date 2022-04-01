namespace CarShop.Data
{
    public class DataConstants
    {
        public const int IdMaxLength = 36;

        public const int UsernameMinLength = 4;
        public const int UsernameMaxLength = 20;

        public const int PasswordMinLength = 5;
        public const int PasswordMaxLength = 20;

        public const string UserEmailRegularExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        public const int ModelNameMinLength = 5;
        public const int ModelNameMaxLength = 20;

        public const int PictureUrlMaxLength = 2048;
        public const int PlateNumberLength = 8;
        public const string PlateNumberRegularExpression = @"^([A-Z]{2}[0-9]{4}[A-Z]{2})$";

        public const int DescriptionMinLength = 5;
        public const int DescriptionMaxLength = 1000;
    }
}
