using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace RSCoreLib
    {
    public static class Crypto
        {
        public static string ToSHA1Base64 (byte[] data)
            {
            using (SHA1 hasher = SHA1.Create())
                {
                byte[] hash = hasher.ComputeHash(data);
                return Convert.ToBase64String(hash);
                }
            }

        public static byte[] ToSHA512 (byte[] data)
            {
            using (SHA512 hasher = SHA512.Create())
                {
                return hasher.ComputeHash(data);
                }
            }

        
        public static byte[] GetStrongRandomBytes(int length)
            {
            using (RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider())
                {
                byte[] result = new byte[length];
                rngCsp.GetBytes(result);
                return result;
                }
            }

        public const byte KAUTH_VERSION = 1;
        public const int SALT_SIZE = 32;
        private const int TOKEN_LENGTH = 1 + SALT_SIZE + 64;

        public static bool VerifyKAuth (string password, byte[] token)
            {
            if (string.IsNullOrWhiteSpace(password) || token == null || token.Length != TOKEN_LENGTH)
                return false;

            byte version = token[0];
            if (version != KAUTH_VERSION)
                return false;

            byte[] salt = new byte[SALT_SIZE];
            Buffer.BlockCopy(token, 1, salt, 0, SALT_SIZE);

            byte[] hash = new byte[64];
            Buffer.BlockCopy(token, 33, hash, 0, 64);

            byte[] calculation = ToSHA512(salt.Concat(Encoding.UTF8.GetBytes(password)).ToArray());
            return calculation.SequenceEqual(hash);
            }

        public static byte[] GenerateKAuthToken(string password)
            {
            Guard.NotNullOrWhitespace(password);

            byte[] bytes = Encoding.UTF8.GetBytes(password);
            byte[] salt = GetStrongRandomBytes(SALT_SIZE);
            byte[] salted = new byte[SALT_SIZE + bytes.Length];
            Buffer.BlockCopy(salt, 0, salted, 0, SALT_SIZE);
            Buffer.BlockCopy(bytes, 0, salted, SALT_SIZE, bytes.Length);

            var hash = ToSHA512(salted);

            byte[] result = new byte[TOKEN_LENGTH];
            result[0] = KAUTH_VERSION;
            Buffer.BlockCopy(salt, 0, result, 1, SALT_SIZE);
            Buffer.BlockCopy(hash, 0, result, 33, 64);
            return result;
            }
        }
    }
