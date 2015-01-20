// Trucks reserve (https://github.com/raste/TrucksReserve)(http://tr.wiadvice.com/)
// Copyright (c) 2015 Georgi Kolev. 
// Licensed under Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0).

using System.Linq;

using DataLayer;
using ToolsLibrary;

namespace BusinessLayer.Classes
{
    public class Accounts
    {
        public static bool IsValidUser(string userName, string password)
        {
            userName = userName.GetTrimmed();

            userName.ExcIfNullOrEmpty();
            password.ExcIfNullOrEmpty();

            bool result = false;

            using (TrucksReserveEntities dc = new TrucksReserveEntities())
            {
                User dbUser = dc.Users.FirstOrDefault(u => u.Name == userName);
                if (dbUser != null)
                {
                    dbUser.Password.ExcIfNullOrEmpty();

                    result = Passwords.CheckPassword(password, dbUser.Password);
                }
            }

            return result;
        }
    }
}
