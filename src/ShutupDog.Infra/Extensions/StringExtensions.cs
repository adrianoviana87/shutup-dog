using ShutupDog.Infra.Globalization;

namespace ShutupDog.Infra.Extensions
{
    public static class StringExtensions
    {
        public static double ToDouble(this string str)
        {
            return double.Parse(str, System.Globalization.NumberStyles.AllowDecimalPoint, Cultures.UsEn);
        }
    }
}