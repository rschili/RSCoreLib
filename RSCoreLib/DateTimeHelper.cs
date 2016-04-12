using System;
using System.Numerics;

namespace RSCoreLib
    {
    //Converts a DateTime which has to be after year 2016 into a short file system compatible string
    public static class DateTimeHelper
        {
        private static DateTime _year2000 = new DateTime(2000, 1, 1);
        private static DateTime _shortStampBeginning = new DateTime(2016, 1, 1);

        public static string GetShortTimeStamp()
            {
            var now = DateTime.Now;
            if (now < _shortStampBeginning)
                throw new ArgumentException("The current date must not be before 2016.");

            var d = now.Subtract(_shortStampBeginning);
            var i = new BigInteger(d.TotalSeconds);
            return StringEncoder.ToString(i, StringEncoder.BASE36CHARS);
            }

        public static DateTime ParseShortTimeStamp (string stamp)
            {
            BigInteger bigInt = StringEncoder.FromString(stamp, StringEncoder.BASE36CHARS);

            double dbl = (double)bigInt;
            return _shortStampBeginning.AddSeconds(dbl);
            }
        }
    }
