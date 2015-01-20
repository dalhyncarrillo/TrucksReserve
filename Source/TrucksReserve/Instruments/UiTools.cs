﻿﻿// Trucks reserve (https://github.com/raste/TrucksReserve)(http://tr.wiadvice.com/)
// Copyright (c) 2015 Georgi Kolev. 
// Licensed under Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0).

namespace TrucksReserve.Instruments
{
    public static class UiTools
    {
        public static void NewUiException(string msg)
        {
            throw new UiException(msg);
        }
    }
}