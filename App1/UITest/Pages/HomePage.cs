using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace UITest
{
    class LoginPage : BasePage
    {
        readonly Query loginButton;
        readonly Query item;
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
                item = x => x.Marked("Third item");
            }
            if (OniOS)
            {
                loginButton = x => x.Marked("Browse");
                item = x => x.Marked("Third item");
            }
        }

        public LoginPage Clicker()
        {
            app.WaitForElement(loginButton);
            app.Tap(loginButton);
            app.WaitForElement(item);

            return this;
        }
    }
}
