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
            app.Screenshot("First screen.").MoveTo(@"Users/runner/screenshots/applaunch");
        }

        [Test]
        public void Clicker()
        {
            app.Screenshot("hurga durga screen.").MoveTo(@"Users/runner/screenshots/hurgadurga");
            new LoginPage()
                .Clicker();
        }
    }

}
