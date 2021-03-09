using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.POPSample;
using System;
using UITest.Pages;
using System.IO;

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
            Screenshot("AppLaunches", "Screenshot-1");
        }

        [Test]
        public void Clicker()
        {
            Screenshot("Clicker", "Screenshot-1");
            new LoginPage()
                .Clicker();
            Screenshot("Clicker", "Screenshot-2");
        }

        public void Screenshot(String directory, String name)
        {
            var fi = app.Screenshot(name);
            var screenShotPath = Path.Combine(Directory.GetCurrentDirectory(), $"screenshots\\{directory}");
            if (!Directory.Exists(screenShotPath))
            {
                Directory.CreateDirectory(screenShotPath);
            }
            var filePath = Path.Combine(screenShotPath, $"{name}.png");

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            fi.MoveTo(filePath);
        }
    }

}
