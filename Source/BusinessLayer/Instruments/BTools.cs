// Trucks reserve (https://github.com/raste/TrucksReserve)(http://tr.wiadvice.com/)
// Copyright (c) 2015 Georgi Kolev. 
// Licensed under Apache License, Version 2.0 (http://www.apache.org/licenses/LICENSE-2.0).

namespace BusinessLayer.Instruments
{
    public static class BTools
    {
        public static ImageType GetImageType(this int i)
        {
            ImageType it = ImageType.Unknown;

            it = (ImageType)i;
            if (it == ImageType.Unknown)
            {
                NewBException(string.Format("Не можа да парсне int {0} към ImageType.", i));
            }

            return it;
        }

        public static TextType GetTextType(this int i)
        {
            TextType tt = TextType.Unknown;

            tt = (TextType)i;
            if (tt == TextType.Unknown)
            {
                NewBException(string.Format("Не можа да парсне int {0} към TextType.", i));
            }

            return tt;
        }

        public static void NewBException(string msg)
        {
            throw new BException(msg);
        }
    }
}
