namespace МоитеГуми.Data.Models
{
    public class DataConstatnt
    {
        public class Connection
        {
            public const string ConnectionString = "Връзка с нас";
            public const string Privacy = "Условия за ползване";
        }
        public class User
        {
            public const int FullNameMaxLength = 40;
            public const int FullNameMinLength = 5;
            public const int PasswordMaxLength = 100;
            public const int PasswordMinLength = 6;
        }
        public class Obqwa
        {
            public const int carMax = 20;
            public const int ObqvaMinLength = 3;
            public const int SizeMinLength = 3;
            public const int SizeMaxLength = 30;
            public const int DescriptionMinLength = 3;
            public const int DescriptionMaxLength = 77;
            public const int TireYearMinValue = 2000;
            public const int TireYearMaxvalue = 2050;

        }
        public class Dealer
        {

            public const int NameMinLength = 2;
            public const int NameMaxLength = 37;
            public const int PhoneMaxLength = 20;
            public const int PhoneMinLength = 6;
        }
        public class Category
        {

            public const int NameMaxLength = 37;
        }


    }
}
