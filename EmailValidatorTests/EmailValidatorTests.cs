using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmailValidatorApp;
using System.Collections.Generic;

namespace EmailValidatorTests
{
    [TestClass]
    public class EmailValidatorTests
    {
        public Dictionary<string, string> validEmails;
        public Dictionary<string, string> invalidEmails;

        [TestInitialize]
        public void TestInitialize()
        {
            validEmails = new Dictionary<string, string>
            {
                { "ValidEmail1", "test@example.com" },
                { "ValidEmail2", "another.test@domain.com" },
                { "ValidEmail3", "valid.email@domain.com" },
                { "ValidEmail4", "email@domain.com" },
                { "ValidEmail5", "first.last@domain.com" },
                { "ValidEmail6", "email@sub.domain.com" },
                { "ValidEmail7", "email+alias@domain.com" },
                { "ValidEmail8", "1234567890@domain.com" },
                { "ValidEmail9", "email@123.123.123.123" },
                { "ValidEmail10", "user@domain.com" }
            };

            invalidEmails = new Dictionary<string, string>
            {
                { "InvalidEmail1", "invalidemail@" },
                { "InvalidEmail2", "another.test@domain" },
                { "InvalidEmail3", "no@spaces allowed.com" },
                { "InvalidEmail4", "toomanycharactersinthislocalparttoomanycharactersinthislocalparttoomanycharactersinthislocalparttoomanycharactersinthislocalparttoomanycharactersinthislocalparttoomanycharactersinthislocalparttoomanycharactersinthislocalparttoomanycharactersinthislocalparttoomanycharactersinthislocalparttoomanycharactersinthislocalpart\r\n@example.com" },
                { "InvalidEmail5", "invalid@missingdotcom" },
                { "InvalidEmail6", "name@verylongdomainpartname@verylongdomainpartname@verylongdomainpartname@verylongdomainpartname.com" },
                { "InvalidEmail7", "@missinglocal.com" },
                { "InvalidEmail8", "missingat.com" },
                { "InvalidEmail9", "missingdomain@.com" },
                { "InvalidEmail10", "@.com" }
            };
        }

        [TestMethod]
        public void ValidateValidEmails()
        {
            foreach (var kvp in validEmails)
            {
                string email = kvp.Value;
                Assert.IsTrue(EmailValidator.IsValidEmail(email), $"Email '{email}' should be valid.");
            }
        }

        [TestMethod]
        public void ValidateInvalidEmails()
        {
            foreach (var kvp in invalidEmails)
            {
                string email = kvp.Value;
                Assert.IsFalse(EmailValidator.IsValidEmail(email), $"Email '{email}' should be invalid.");
            }
        }
    }
}
