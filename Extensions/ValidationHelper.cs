namespace AISQLQueryGenerator.API.Extensions
{
    public static class ValidationHelper
    {
        public static bool IsValid(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                return false;

            if (description.Length < 5)
                return false;

            return true;
        }
    }
}