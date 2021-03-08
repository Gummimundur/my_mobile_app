using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.POPSample;
using System;
using UITest.Pages;

namespace UITest
{
    public class Tests : BaseTestFixture
    {
        public Tests(Platform platform)
            : base(platform)
        {
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
        }

        [Test]
        public void Clicker()
        {
            new LoginPage()
                .Clicker();
        }
    }

}
