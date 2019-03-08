using HomeBudgetManager.Application.Interfaces.Utils.Cryptography;
using HomeBudgetManager.Common.Extensions;
using System;
using System.Security.Cryptography;

namespace HomeBudgetManager.Infrastructure.Utils.Cryptography
{
    public class Encrypter : IEncrypter
    {
        private const int SaltSize = 40;
        private const int DeriveBytesIterationCount = 1000;

        public string GetSalt(string value)
        {
            if (value.IsEmpty())
            {
                throw new ArgumentException("Can not generate salt from empty value", nameof(value));
            }

            var saltBytes = new byte[SaltSize];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(saltBytes);

            return Convert.ToBase64String(saltBytes);
        }

        public string GetHash(string value, string salt)
        {
            if (value.IsEmpty())
            {
                throw new ArgumentException("Can not generate hash from empty value", nameof(value));
            }
            if (salt.IsEmpty())
            {
                throw new ArgumentException("Can not generate hash with empty salt", nameof(salt));
            }

            var rfc = new Rfc2898DeriveBytes(value, GetBytes(salt), DeriveBytesIterationCount);

            return Convert.ToBase64String(rfc.GetBytes(SaltSize));
        }

        private byte[] GetBytes(string value)
        {
            var bytes = new byte[value.Length * sizeof(char)];
            Buffer.BlockCopy(value.ToCharArray(), 0, bytes, 0, bytes.Length);

            return bytes;
        }
    }
}
