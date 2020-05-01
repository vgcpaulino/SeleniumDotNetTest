﻿using FarfetchSeleniumTest.Fixtures;
using FarfetchSeleniumTest.Helpers;
using FarfetchSeleniumTest.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xunit;
using Xunit.Abstractions;

namespace FarfetchSeleniumTest.Tests
{
    public class MenuLowerResolutionTests : IClassFixture<TestFixture>
    {

        private readonly IWebDriver driver;
        private readonly ITestOutputHelper output;
        private readonly WindowManagerHelper window;
        private readonly HomePO home;

        private readonly EnvironmentHelper env;

        public MenuLowerResolutionTests(TestFixture fixture, ITestOutputHelper output)
        {
            driver = fixture.Driver;
            this.output = output;

            window = new WindowManagerHelper(driver);
            home = new HomePO(driver);
            
            window.SetWindowSize(1000, 890, 1, 1);


            env = new EnvironmentHelper();
        }

        [Fact]
        public void SideMenuMustBeDisplayedBelow1000Width()
        {
            // ARRANGE: 
            home.OpenHomePage();

            // ACT: 
            window.SetWindowSize(1000, 890, 1, 1);

            // ASSERT: 
            Assert.True(home.SideMenu.Displayed);
        }

        [Fact]
        public void SideMenuMustNotBeDisplayedAbove1000Width()
        {
            // ARRANGE: 
            home.OpenHomePage();

            // ACT: 
            driver.Manage().Window.Maximize();

            // ASSERT: 
            Assert.False(home.SideMenu.Displayed);
        }
        
    }
}