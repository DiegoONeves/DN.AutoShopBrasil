using System.Text.RegularExpressions;

namespace DN.AutoShopBrasil.Domain.Validations
{
    public class EmailValidation
    {
        public static bool IsValid(string email)
        {
            if (email == null)
                return false;

            return Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }
    }
}
