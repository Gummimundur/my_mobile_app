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
            var fi = app.Screenshot("App launches");
            SaveScreenshot(fi, "Test1-AppLaunches");
        }

        [Test]
        public void Clicker()
        {
            var fi = app.Screenshot("Beforeclick");
            SaveScreenshot(fi, "Test2-BeforeClick");
            new LoginPage()
                .Clicker();
            fi = app.Screenshot("After click");
            SaveScreenshot(fi, "Test2-AfterClick");
        }

        public void SaveScreenshot(FileInfo fi, String name)
        {
            var screenShotPath = Path.Combine(Directory.GetCurrentDirectory(), "screenshots");
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
