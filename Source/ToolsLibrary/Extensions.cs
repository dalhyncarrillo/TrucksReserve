// Trucks reserve (https://github.com/raste/TrucksReserve)(http://tr.wiadvice.com/)
// Copyright (c) 2015 Georgi Kolev. 
// Licensed under Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0).

using System;
using System.Collections.Generic;
using System.Linq;

namespace ToolsLibrary
{
    public static class Extensions
    {
        public static void ExcIfNull(this object obj)
        {
            if (obj == null) 
            {
                throw new ArgumentException("Обект подаден на ToolsLibrary.Extensions е null.");
            }
        }

        public static void ExcIfNullOrEmpty(this string str)
        {
            if (str.GetTrimmed().IsEmpty() == true)
            {
                throw new ArgumentException("string подаден на ToolsLibrary.Extensions е null или empty.");
            }
        }

        public static string GetTrimmed(this string str)
        {
            if (str.IsEmpty() == false)
            {
                return str.Trim();
            }
            else
            {
                return string.Empty;
            }
        }

        public static bool IsEmpty(this string str)
        {
            if (string.IsNullOrEmpty(str) == true || str.Trim().Length < 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool AreThereItems<T>(this IEnumerable<T> collection)
        {
            if (collection == null || collection.Count() == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool IsValidEmailAddress(this string str)
        {
            bool result = false;

            if (str.IsEmpty() == false)
            {
                System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$");
                result = reg.IsMatch(str);
            }

            return result;
        }

    }
}
