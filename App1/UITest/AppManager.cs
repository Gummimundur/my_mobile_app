using System;
using System.IO;
using System.Reflection;
using Xamarin.UITest;
using Xamarin.UITest.Utils;

namespace UITest
{
    static class AppManager
    {
        // const string AppPath = "../../../Binaries/TaskyiOS.app"; // File not .app file. Not configured yet
        const string IpaBundleId = "com.companyname.marvinmobile.apk";

        static IApp app;
        public static IApp App
        {
            get
            {
                if (app == null)
                    throw new NullReferenceException("'AppManager.App' not set. Call 'AppManager.StartApp()' before trying to access it.");
                return app;
            }
        }

        static Platform? platform;
        public static Platform Platform
        {
            get
            {
                if (platform == null)
                    throw new NullReferenceException("'AppManager.Platform' not set.");
                return platform.Value;
            }

            set
            {
                platform = value;
            }
        }

        public static void StartApp()
        {
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            if (Platform == Platform.Android)
            {
                app = ConfigureApp
                    .Android
                    .EnableLocalScreenshots()
                    .PreferIdeSettings()
                    .ApkFile("../../../../binaries/com.companyname.app1.apk")
                    .StartApp();
            }

            if (Platform == Platform.iOS)
            {
                const string simId = "13D49245-F338-460D-902A-4B993359ACDC";
                app = ConfigureApp
                    .iOS
                    .EnableLocalScreenshots()
                    .PreferIdeSettings()
                    .WaitTimes(new WaitTimes())
                    .DeviceIdentifier(simId)
                    .AppBundle("../../../../binaries/App1.iOS/bin/iPhoneSimulator/Release/App1.iOS.app")
                    .StartApp();
            }
        }

        public class WaitTimes : IWaitTimes
        {
            public TimeSpan GestureCompletionTimeout => TimeSpan.FromMinutes(0.1);
            public TimeSpan GestureWaitTimeout => TimeSpan.FromMinutes(0.1);
            public TimeSpan WaitForTimeout => TimeSpan.FromMinutes(0.1);
        }
    }
}
