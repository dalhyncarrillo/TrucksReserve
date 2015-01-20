// Trucks reserve (https://github.com/raste/TrucksReserve)(http://tr.wiadvice.com/)
// Copyright (c) 2015 Georgi Kolev. 
// Licensed under Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0).

using System;
using System.Security.Cryptography;
using System.Text;

namespace ToolsLibrary
{
    public class Passwords
    {
        private static readonly int saltBytesNumber = 20;

        /// <summary>
        /// Checks if user typed password is equal to the hashed one
        /// </summary>
        /// <returns>true id they are equal,otherwise false</returns>
        public static bool CheckPassword(string password, string storedHashedPass)
        {
            password = password.GetTrimmed();
            password.ExcIfNullOrEmpty();
            storedHashedPass.ExcIfNullOrEmpty();

            bool passed = false;
            string salt = storedHashedPass.Substring(storedHashedPass.Length - (2 * saltBytesNumber));

            ///
            String SaltedPassword = string.Format("{0}{1}", salt, password);

            UTF8Encoding encoder = new UTF8Encoding();
            SHA256CryptoServiceProvider sha256hasher = new SHA256CryptoServiceProvider();
            byte[] hashed256bytes = sha256hasher.ComputeHash(encoder.GetBytes(SaltedPassword));
            StringBuilder output = new StringBuilder("");
            for (int i = 0; i < hashed256bytes.Length; i++)
            {
                output.Append(hashed256bytes[i].ToString("X2"));
            }
            ///

            output.Append(salt);

            if (storedHashedPass.Equals(output.ToString()))
            {
                passed = true;
            }

            return passed;
        }


        /// <summary>
        /// Returns hashed password
        /// </summary>
        public static string GetHashed(string password)
        {
            password.ExcIfNullOrEmpty();

            byte[] salt = new byte[saltBytesNumber];
            RNGCryptoServiceProvider Gen = new RNGCryptoServiceProvider();
            Gen.GetBytes(salt);

            StringBuilder saltedPassword = new StringBuilder();
            for (int j = 0; j < salt.Length; j++)
            {
                saltedPassword.Append(salt[j].ToString("X2"));
            }
            saltedPassword.Append(password);

            String SaltedPasswordStr = saltedPassword.ToString();

            UTF8Encoding encoder = new UTF8Encoding();
            SHA256CryptoServiceProvider sha256hasher = new SHA256CryptoServiceProvider();
            byte[] hashed256bytes = sha256hasher.ComputeHash(encoder.GetBytes(SaltedPasswordStr));

            StringBuilder output = new StringBuilder("");
            for (int i = 0; i < hashed256bytes.Length; i++)
            {
                output.Append(hashed256bytes[i].ToString("X2"));
            }

            for (int k = 0; k < salt.Length; k++)
            {
                output.Append(salt[k].ToString("X2"));
            }

            return output.ToString();
        }
    }
}
