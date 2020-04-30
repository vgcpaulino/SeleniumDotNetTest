﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarfetchSeleniumTest.Helpers
{
    public class InputHelper
    {

        public void ClearInputAndType(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

    }
}
