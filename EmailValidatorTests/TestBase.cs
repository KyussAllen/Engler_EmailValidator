﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EmailValidatorTests
{
    
    public class TestBase
    {
        public TestContext? TestContext { get; set; }

        public T GetTestSetting<T>(string name, T defaultValue)
        {
            T returnValue = defaultValue;

            try
            {
                var temp = TestContext?.Properties[name];
                if (temp != null)
                {
                    returnValue = (T)Convert.ChangeType(temp, typeof(T));
                }
            }
            catch
            {

            }

            return returnValue;
        }

    }
}