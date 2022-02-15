using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Toyota.Auth
{
    public class AuthOptions
    {
        public const string ISSUER = "ToyotaServer"; // издатель токена
        public const string AUDIENCE = "ToyotaClient"; // потребитель токена
        const string KEY = "RJWZ1cCI2ttBUPPmUNEpCNYw0RVNKCjBAS9st17ltBNfATub7wGzBAPJBO13D2s";   // ключ для шифрации
        public const int LIFETIME = 1; // время жизни токена - 1 минута
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
