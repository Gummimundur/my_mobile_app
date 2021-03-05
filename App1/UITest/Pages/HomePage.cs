﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest.POPSample;

using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace UITest.Pages
{
    class LoginPage : BasePage
    {
        readonly Query loginButton;
        readonly Query press;
        protected override PlatformQuery Trait => new PlatformQuery
        {
            Android = x => x.Marked("Browse"),
            iOS = x => x.Marked("Browse")
        };

        public LoginPage()
        {
            if (OnAndroid)
            {
                loginButton = x => x.Marked("Browse");
            }
        }

        public LoginPage Clicker()
        {
            app.WaitForElement(loginButton);
            app.Tap(loginButton);


            return this;
        }
    }
}