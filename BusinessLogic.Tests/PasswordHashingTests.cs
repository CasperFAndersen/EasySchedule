using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogic.Tests
{
    [TestClass]
    public class PasswordHashingTests
    {
        [TestMethod]
        public void PasswordIsHashedTest()
        {
            string input = "Password";
            string output = PasswordHashing.HashPassword(input);
            Assert.AreNotEqual(input, output);
        }
    }
}
