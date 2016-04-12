using System;
using System.Linq;

namespace RSCoreLib
    {
    public static class RandomStringGenerator
        {
        [Obsolete("Slow because of linq, use GenerateStrongBase64 instead", false)]
        public static string Generate (int length)
            {
            var random = new Random();
            return new string(Enumerable.Range(0, length).Select(i => StringEncoder.BASE62CHARS[random.Next(StringEncoder.BASE62CHARS.Length)]).ToArray());
            }

        public static string GenerateStrongBase64 (int lengthInBytes)
            {
            return Convert.ToBase64String(Crypto.GetStrongRandomBytes(lengthInBytes));
            }
        }
    }
