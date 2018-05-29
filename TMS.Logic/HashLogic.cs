using System;
using System.Text;

namespace TMS.Logic
{
    public class HashLogic
    {
        private int Size = 11;

        public string CreateHash(string tobehashed)
        {
            string hashed = GenerateSha256(tobehashed, GenerateSalt());
            return hashed;
        }

        private string GenerateSalt()
        {
            try
            {
                var rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
                var buff = new byte[this.Size];
                rng.GetBytes(buff);

                return Convert.ToBase64String(buff);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }

        private string GenerateSha256(string input, string salt)
        {
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input + salt);
                System.Security.Cryptography.SHA256Managed sha256Hash = new System.Security.Cryptography.SHA256Managed();
                byte[] hash = sha256Hash.ComputeHash(bytes);

                return Convert.ToBase64String(hash);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }
    }
}