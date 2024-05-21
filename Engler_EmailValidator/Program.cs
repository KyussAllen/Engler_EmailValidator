using System;

namespace EmailValidatorApp
{
    public class EmailValidator
    {
        static void Main(string[] args)
        {
            bool isValid = IsValidEmail("example@example.com");
            Console.WriteLine($"Is email valid? {isValid}");
        }
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            if (email.Contains(" "))
                return false;

            int atIndex = email.IndexOf('@');
            if (atIndex < 1 || atIndex != email.LastIndexOf('@'))
                return false;

            string localPart = email.Substring(0, atIndex);
            string domainPart = email.Substring(atIndex + 1);

            if (localPart.Length < 1 || localPart.Length > 100 || domainPart.Length < 3 || domainPart.Length > 100)
                return false;

            int dotIndex = domainPart.IndexOf('.');
            if (dotIndex < 1 || dotIndex == domainPart.Length - 1)
                return false;

            foreach (char c in localPart)
            {
                if (!char.IsLetterOrDigit(c) && c != '.' && c != '_' && c != '-' && c != '+')
                {
                    return false;
                }
            }

            string[] domainSegments = domainPart.Split('.');
            if (domainSegments.Length <= 2)
                return false;

            foreach (string segment in domainSegments)
            {
                if (string.IsNullOrEmpty(segment) || segment.Length > 63)
                {
                    return false;
                }

                if (!char.IsLetterOrDigit(segment[0]) || !char.IsLetterOrDigit(segment[segment.Length - 1]))
                {
                    return false;
                }

                foreach (char c in segment)
                {
                    if (!char.IsLetterOrDigit(c) && c != '-')
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
