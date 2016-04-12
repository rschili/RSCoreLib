using Microsoft.VisualStudio.TestTools.UnitTesting;
using RSCoreLib;

namespace RSCoreLibTest
    {
    [TestClass]
    public class CryptoTests
        {
        [TestMethod]
        public void TestKAuth ()
            {
            const string testPassword = "MyTest _ # Password";
            var bytes = Crypto.GenerateKAuthToken(testPassword);
            Assert.IsNotNull(bytes);
            Assert.IsFalse(Crypto.VerifyKAuth("ASDF", bytes));
            Assert.IsFalse(Crypto.VerifyKAuth("MyTest _ # P", bytes));
            Assert.IsTrue(Crypto.VerifyKAuth(testPassword, bytes));
            }
        }
    }
