﻿using System;
using System.IO;
using System.Reflection;
using Xamarin.UITest;

namespace Xamarin.UITest.POPSample
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
                    .ApkFile("../../../App1/App1.Android/bin/Release/com.companyname.app1.apk")
                    .StartApp();
            }
            // Ios not configured yet
            //if (Platform == Platform.iOS)
            //{
            //    app = ConfigureApp
            //        .iOS
            //        // Used to run a .app file on an ios simulator:
            //        .AppBundle(AppPath)
            //        // Used to run a .ipa file on a physical ios device:
            //        //.InstalledApp(ipaBundleId)
            //        .StartApp();
            //}
        }
    }
}
