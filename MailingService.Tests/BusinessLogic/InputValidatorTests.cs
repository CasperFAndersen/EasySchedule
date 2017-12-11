using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;
using System.Collections.Generic;

namespace Tests.BusinessLogic
{
    [TestClass]
    public class InputValidatorTests
    {
        readonly InputValidator _iv = new InputValidator();
        //[TestMethod]
        //public void TestEmailValidator()
        //{
        //   
        //}

        [TestMethod]
        public void PhoneInputCheckTest()
        {
            String[] PhoneNumbers =
            {
                // 3 invalid          
                "123456",
                "1",
                "21",

                // 6 valid
                "45698526",
                "45869532",
                "123456789123456789",
                "123456789963582",
                "123456789",
                "12365896"
            };
            List<string> passedPhoneNumbers = new List<string>();
            List<string> failedPhoneNumbers = new List<string>();

            string sPattern = _iv.EmployeePhoneCheck;
            foreach (string s in PhoneNumbers)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(s, sPattern))
                {
                    passedPhoneNumbers.Add(s);
                }
                else
                {
                    failedPhoneNumbers.Add(s);
                }
            }
            
            Assert.AreEqual(3, failedPhoneNumbers.Count);
            Assert.AreEqual(6, passedPhoneNumbers.Count);
        }

        [TestMethod]
        public void EmailInputCheckTest()
        {
            String[] emails =
            {
                "Casper@thisemail.com",
                "Casper.this@thisemail.com",
                "Stefan..This@email.com",

                "mikkel,paulsen@thisemail.com",
                "mikkel.paulsen@thisemail,com"
                };
            List<string> passedEmails = new List<string>();
            List<string> failedEmails = new List<string>();

            string sPattern = _iv.EmployeeEmailCheck;
            foreach (string s in emails)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(s, sPattern))
                {
                    passedEmails.Add(s);
                }
                else
                {
                    failedEmails.Add(s);
                }
            }

            Assert.AreEqual(3, passedEmails.Count);
            Assert.AreEqual(2, failedEmails.Count);
        }

    }
}
