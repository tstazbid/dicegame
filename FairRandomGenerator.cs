using System;
using System.Security.Cryptography;
using System.Text;

namespace DiceGame
{
    public class FairRandomGenerator
    {
        public static (string hmac, string key, int randomValue) GenerateHMAC(int range)
        {
            using var hmac = new HMACSHA256();
            var key = Convert.ToHexString(hmac.Key);
            var random = new Random();
            var randomValue = random.Next(range);
            var hmacValue = hmac.ComputeHash(Encoding.UTF8.GetBytes(randomValue.ToString()));
            return (Convert.ToHexString(hmacValue), key, randomValue);
        }
    }
}
