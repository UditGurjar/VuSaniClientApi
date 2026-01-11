using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VuSaniClientApi.Models.Helpers
{
    public static class PasswordHelper
    {
        public static string HashPassword(string password, string hashAlgorithm, byte[] saltValue)
        {
            RNGCryptoServiceProvider rng = null;
            HashAlgorithm hash = null;
            try
            {
                // If salt is not specified, generate it on the fly.
                if (saltValue == null)
                {
                    // Define min and max salt sizes.
                    int minSaltSize = 4;
                    int maxSaltSize = 8;

                    // Generate a random number for the size of the salt.
                    Random random = new Random();
                    int saltSize = random.Next(minSaltSize, maxSaltSize);

                    // Allocate a byte array, which will hold the salt.
                    saltValue = new byte[saltSize];

                    // Initialize a random number generator.
                    rng = new RNGCryptoServiceProvider();

                    // Fill the salt with cryptographically strong byte values.
                    rng.GetNonZeroBytes(saltValue);
                }

                // Convert plain text into a byte array.
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(password);

                // Allocate array, which will hold plain text and salt.
                byte[] plainTextWithSaltBytes =
                        new byte[plainTextBytes.Length + saltValue.Length];

                // Copy plain text bytes into resulting array.
                for (int i = 0; i < plainTextBytes.Length; i++)
                    plainTextWithSaltBytes[i] = plainTextBytes[i];

                // Append salt bytes to the resulting array.
                for (int i = 0; i < saltValue.Length; i++)
                    plainTextWithSaltBytes[plainTextBytes.Length + i] = saltValue[i];



                // Make sure hashing algorithm name is specified.
                if (hashAlgorithm == null)
                    hashAlgorithm = "";

                // Initialize appropriate hashing algorithm class.
                switch (hashAlgorithm.ToUpper(new CultureInfo("en-US", false)))
                {
                    case "SHA1":
                        hash = new SHA1Managed();
                        break;

                    case "SHA256":
                        hash = new SHA256Managed();
                        break;

                    case "SHA384":
                        hash = new SHA384Managed();
                        break;

                    case "SHA512":
                        hash = new SHA512Managed();
                        break;

                    default:
                        hash = new MD5CryptoServiceProvider();
                        break;
                }

                // Compute hash value of our plain text with appended salt.
                byte[] hashBytes = hash.ComputeHash(plainTextWithSaltBytes);



                // Create array which will hold hash and original salt bytes.
                byte[] hashWithSaltBytes = new byte[hashBytes.Length +
                                                    saltValue.Length];

                // Copy hash bytes into resulting array.
                for (int i = 0; i < hashBytes.Length; i++)
                    hashWithSaltBytes[i] = hashBytes[i];

                // Append salt bytes to the result.
                for (int i = 0; i < saltValue.Length; i++)
                    hashWithSaltBytes[hashBytes.Length + i] = saltValue[i];

                // Convert result into a base64-encoded string.
                string hashValue = Convert.ToBase64String(hashWithSaltBytes);



                // Return the result.
                return hashValue;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                hash.Dispose();
            }
        }

        private static HMAC GetHashAlgorithm(string hashAlgorithm, byte[]? salt = null)
        {
            switch (hashAlgorithm.ToUpperInvariant())
            {
                case "SHA1":
                    return new HMACSHA1(salt ?? GenerateSalt());
                case "SHA256":
                    return new HMACSHA256(salt ?? GenerateSalt());
                case "SHA384":
                    return new HMACSHA384(salt ?? GenerateSalt());
                case "SHA512":
                    return new HMACSHA512(salt ?? GenerateSalt());
                default:
                    throw new ArgumentException($"Invalid hash algorithm: {hashAlgorithm}");
            }
        }

        public static bool VerifyPassword(string password, string hashedPassword, string hashAlgorithm)
        {
            // Convert base64-encoded hash value into a byte array.
            byte[] hashWithSaltBytes = Convert.FromBase64String(hashedPassword);

            // We must know size of hash (without salt).
            int hashSizeInBits, hashSizeInBytes;

            // Make sure that hashing algorithm name is specified.
            if (hashAlgorithm == null)
                hashAlgorithm = "";

            // Size of hash is based on the specified algorithm.
            switch (hashAlgorithm.ToUpper(new CultureInfo("en-US", false)))
            {
                case "SHA1":
                    hashSizeInBits = 160;
                    break;

                case "SHA256":
                    hashSizeInBits = 256;
                    break;

                case "SHA384":
                    hashSizeInBits = 384;
                    break;

                case "SHA512":
                    hashSizeInBits = 512;
                    break;

                default: // Must be MD5
                    hashSizeInBits = 128;
                    break;
            }

            // Convert size of hash from bits to bytes.
            hashSizeInBytes = hashSizeInBits / 8;

            // Make sure that the specified hash value is long enough.
            if (hashWithSaltBytes.Length < hashSizeInBytes)
                return false;

            // Allocate array to hold original salt bytes retrieved from hash.
            byte[] saltBytes = new byte[hashWithSaltBytes.Length -
                                        hashSizeInBytes];

            // Copy salt from the end of the hash to the new array.
            for (int i = 0; i < saltBytes.Length; i++)
                saltBytes[i] = hashWithSaltBytes[hashSizeInBytes + i];

            // Compute a new hash string.
            string expectedHashString =
                        ComputeHash(password, hashAlgorithm, saltBytes);

            // If the computed hash matches the specified hash,
            // the plain text value must be correct.

            return (hashedPassword == expectedHashString);
        }

        private static byte[] GenerateSalt(int size = 64)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var salt = new byte[size];
                rng.GetBytes(salt);
                return salt;
            }
        }

        /// <summary>
        /// Function is used to generated encrypted password.
        /// </summary>
        /// <param name="plain">User defined password</param>
        /// <param name="hashAlgorithm">SHA1</param>
        /// <param name="saltValue"></param>
        /// <returns></returns>
        public static string ComputeHash(string plain, string hashAlgorithm, byte[] saltValue)
        {
            RNGCryptoServiceProvider rng = null;
            HashAlgorithm hash = null;
            try
            {
                // If salt is not specified, generate it on the fly.
                if (saltValue == null)
                {
                    // Define min and max salt sizes.
                    int minSaltSize = 4;
                    int maxSaltSize = 8;

                    // Generate a random number for the size of the salt.
                    Random random = new Random();
                    int saltSize = random.Next(minSaltSize, maxSaltSize);

                    // Allocate a byte array, which will hold the salt.
                    saltValue = new byte[saltSize];

                    // Initialize a random number generator.
                    rng = new RNGCryptoServiceProvider();

                    // Fill the salt with cryptographically strong byte values.
                    rng.GetNonZeroBytes(saltValue);
                }

                // Convert plain text into a byte array.
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(plain);

                // Allocate array, which will hold plain text and salt.
                byte[] plainTextWithSaltBytes =
                        new byte[plainTextBytes.Length + saltValue.Length];

                // Copy plain text bytes into resulting array.
                for (int i = 0; i < plainTextBytes.Length; i++)
                    plainTextWithSaltBytes[i] = plainTextBytes[i];

                // Append salt bytes to the resulting array.
                for (int i = 0; i < saltValue.Length; i++)
                    plainTextWithSaltBytes[plainTextBytes.Length + i] = saltValue[i];



                // Make sure hashing algorithm name is specified.
                if (hashAlgorithm == null)
                    hashAlgorithm = "";

                // Initialize appropriate hashing algorithm class.
                switch (hashAlgorithm.ToUpper(new CultureInfo("en-US", false)))
                {
                    case "SHA1":
                        hash = new SHA1Managed();
                        break;

                    case "SHA256":
                        hash = new SHA256Managed();
                        break;

                    case "SHA384":
                        hash = new SHA384Managed();
                        break;

                    case "SHA512":
                        hash = new SHA512Managed();
                        break;

                    default:
                        hash = new MD5CryptoServiceProvider();
                        break;
                }

                // Compute hash value of our plain text with appended salt.
                byte[] hashBytes = hash.ComputeHash(plainTextWithSaltBytes);



                // Create array which will hold hash and original salt bytes.
                byte[] hashWithSaltBytes = new byte[hashBytes.Length +
                                                    saltValue.Length];

                // Copy hash bytes into resulting array.
                for (int i = 0; i < hashBytes.Length; i++)
                    hashWithSaltBytes[i] = hashBytes[i];

                // Append salt bytes to the result.
                for (int i = 0; i < saltValue.Length; i++)
                    hashWithSaltBytes[hashBytes.Length + i] = saltValue[i];

                // Convert result into a base64-encoded string.
                string hashValue = Convert.ToBase64String(hashWithSaltBytes);



                // Return the result.
                return hashValue;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                hash.Dispose();
            }
        }

        private static int GetSaltSize(string hashAlgorithm)
        {
            switch (hashAlgorithm.ToUpperInvariant())
            {
                case "SHA1":
                    return 20;
                case "SHA256":
                    return 32;
                case "SHA384":
                    return 48;
                case "SHA512":
                    return 64;
                default:
                    throw new ArgumentException($"Invalid hash algorithm: {hashAlgorithm}");
            }
        }
    }

}
