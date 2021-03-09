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
            var screenshotFolder = Path.Combine(Directory.GetCurrentDirectory(), "screenshots");
            if (!Directory.Exists(screenshotFolder))
            {
                Directory.CreateDirectory(screenshotFolder);
            }
            var fi = app.Screenshot(name);
            var imageDirectoryPath = Path.Combine(screenshotFolder, directory);
            if (!Directory.Exists(imageDirectoryPath))
            {
                Directory.CreateDirectory(imageDirectoryPath);
            }
            var filePath = Path.Combine(imageDirectoryPath, $"{name}.png");

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            fi.MoveTo(filePath);
        }
    }

}
