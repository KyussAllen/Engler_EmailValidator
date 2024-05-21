using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmailValidatorApp;
using System.Collections.Generic;
using NuGet.Frameworks;

namespace EmailValidatorTests
{
    [TestClass]
    public class EmailValidatorTests : TestBase
    {
        private static List<string> validEmails;
        private static List<string> invalidEmails;
        private static List<TestResult> testResults;

        [TestMethod]
        public void ClassInitialize()
        {
            Dictionary<string, string> validEmails = new Dictionary<string, string>()
{
    { "ValidEmail1", "test@example.com" },
    { "ValidEmail2", "another.test@domain.co" },
    { "ValidEmail3", "valid.email@domain.com" },
    { "ValidEmail4", "email@domain.com" },
    { "ValidEmail5", "first.last@domain.com" },
    { "ValidEmail6", "email@sub.domain.com" },
    { "ValidEmail7", "email+alias@domain.com" },
    { "ValidEmail8", "1234567890@domain.com" },
    { "ValidEmail9", "email@123.123.123.123" },
    { "ValidEmail10", "user@domain.com" }
};

            Dictionary<string, string> InvalidEmails = new Dictionary<string, string>()
{
    { "InvalidEmail1", "invalidemail@" },
    { "InvalidEmail2", "another.test@domain" },
    { "InvalidEmail3", "no@spaces allowed.com" },
    { "InvalidEmail4", "toolonglocalparttoolonglocalparttoolonglocalparttoolonglocalparttoolonglocalparttoolonglocalpart@example.com" },
    { "InvalidEmail5", "invalid@missingdotcom" },
    { "InvalidEmail6", "name@verylongdomainpartname@verylongdomainpartname@verylongdomainpartname@verylongdomainpartname.com" },
    { "InvalidEmail7", "@missinglocal.com" },
    { "InvalidEmail8", "missingat.com" },
    { "InvalidEmail9", "missingdomain@.com" },
    { "InvalidEmail10", "@.com" }
};


            
            foreach (KeyValuePair<string, string> kvp in validEmails )
            {

                string ValidEmailTest = GetTestSetting<string>(kvp.Key, kvp.Value);
                Assert.IsTrue(EmailValidator.IsValidEmail(ValidEmailTest));
              
            }

        
         
            foreach (KeyValuePair<string, string> kvp in InvalidEmails)
            {
               string InvalidEmailTest = GetTestSetting<string>(kvp.Key, kvp.Value);
                Assert.IsFalse(EmailValidator.IsValidEmail(InvalidEmailTest));
            }

            testResults = new List<TestResult>();
        }



        
    }
}
