using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogic.Tests
{
    [TestClass]
    public class InputValidatorTests
    {
        private InputValidator _inputValidator;

        [TestInitialize]
        public void TestInitializer()
        {
            _inputValidator = new InputValidator();
        }

        [TestMethod]
        public void PhoneCheckTest()
        {
            String[] phoneNumbers =
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

            string pattern = _inputValidator.PhoneCheck;
            foreach (string input in phoneNumbers)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(input, pattern))
                {
                    passedPhoneNumbers.Add(input);
                }
                else
                {
                    failedPhoneNumbers.Add(input);
                }
            }

            Assert.AreEqual(3, failedPhoneNumbers.Count);
            Assert.AreEqual(6, passedPhoneNumbers.Count);
        }

        [TestMethod]
        public void EmailCheckTest()
        {
            string[] emails =
            {
                "Casper@thisemail.com",
                "Casper.this@thisemail.com",
                "Stefan..This@email.com",

                "mikkel,paulsen@thisemail.com",
                "mikkel.paulsen@thisemail,com"
                };
            List<string> passedEmails = new List<string>();
            List<string> failedEmails = new List<string>();

            string pattern = _inputValidator.EmailCheck;
            foreach (string input in emails)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(input, pattern))
                {
                    passedEmails.Add(input);
                }
                else
                {
                    failedEmails.Add(input);
                }
            }

            Assert.AreEqual(3, passedEmails.Count);
            Assert.AreEqual(2, failedEmails.Count);
        }

        [TestMethod]
        public void NameCheckTest()
        {
            string[] names =
            {
                "Test test",
                "Test test tester",
                "F F",

                "!",
                "test",
                "JegHarToNavne"
            };
            List<string> passedNames = new List<string>();
            List<string> failedNames = new List<string>();

            string pattern = _inputValidator.NameCheck;
            foreach (string input in names)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(input, pattern))
                {
                    passedNames.Add(input);
                }
                else
                {
                    failedNames.Add(input);
                }
            }
            Assert.AreEqual(3, passedNames.Count);
            Assert.AreEqual(3, failedNames.Count);
        }

        [TestMethod]
        public void UsernameCheckTest()
        {
            string[] usernames =
            {
                "Username",
                "Admin",
                "123hej",
                "hej123",

                "!",
                "ab",
                "a"
            };
            List<string> passedUsernames = new List<string>();
            List<string> failedUsernames = new List<string>();

            string pattern = _inputValidator.UsernameCheck;
            foreach (string input in usernames)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(input, pattern))
                {
                    passedUsernames.Add(input);
                }
                else
                {
                    failedUsernames.Add(input);
                }
            }
            Assert.AreEqual(4, passedUsernames.Count);
            Assert.AreEqual(3, failedUsernames.Count);
        }


        [TestMethod]
        public void PasswordCheckTest()
        {
            string[] passwords =
            {
                "minKode",
                "kode123",
                "123hej",
                "hej123",

                "!",
                "ab",
                "a",
            };
            List<string> passedPasswords = new List<string>();
            List<string> failedPasswords = new List<string>();

            string pattern = _inputValidator.PasswordCheck;
            foreach (string input in passwords)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(input, pattern))
                {
                    passedPasswords.Add(input);
                }
                else
                {
                    failedPasswords.Add(input);
                }
            }
            Assert.AreEqual(4, passedPasswords.Count);
            Assert.AreEqual(3, failedPasswords.Count);
        }
    }
}
