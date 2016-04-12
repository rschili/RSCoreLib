using Microsoft.VisualStudio.TestTools.UnitTesting;
using RSCoreLib;

namespace RSCoreLibTest
    {
    [TestClass]
    public class StringHelperTests
        {
        [TestMethod]
        public void TestBase36Encoding ()
            {
            int i = 0;
            string s = StringEncoder.ToBase36String(i);
            int r = StringEncoder.FromBase36String(s);
            Assert.AreEqual(i, r);

            i = int.MaxValue;
            s = StringEncoder.ToBase36String(i);
            r = StringEncoder.FromBase36String(s);
            Assert.AreEqual(i, r);

            i = 42;
            s = StringEncoder.ToBase36String(i);
            r = StringEncoder.FromBase36String(s);
            Assert.AreEqual(i, r);
            }
        }
    }
