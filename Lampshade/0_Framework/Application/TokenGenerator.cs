using System;

namespace _0_Framework.Application
{
    public class TokenGenerator
    {
        public static string GenerateToken()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
