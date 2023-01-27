﻿using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using Owin;


namespace WebApplication2.AppStart
{
    public partial class StartUp
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new Microsoft.Owin.PathString("/Account/Login"),
                LogoutPath = new Microsoft.Owin.PathString("/Account/LogOff"),
                ExpireTimeSpan = TimeSpan.FromMinutes(30.0)
        });
        }
    }
}