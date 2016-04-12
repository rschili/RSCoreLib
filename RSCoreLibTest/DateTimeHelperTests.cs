using System;
using System.Diagnostics;
using RSCoreLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RSCoreLibTest
    {
    [TestClass]
    public class DateTimeHelperTests
        {
        [TestMethod]
        public void TestShortTimeStamp ()
            {
            string stamp = DateTimeHelper.GetShortTimeStamp();
            Assert.IsNotNull(stamp);
            Debug.WriteLine(format: "Stamp as of now: {0}", args: stamp);

            DateTime result = DateTimeHelper.ParseShortTimeStamp(stamp);
            TimeSpan difference = DateTime.Now.Subtract(result);
            Assert.IsTrue(difference.TotalSeconds < 2);
            }
        }
    }
