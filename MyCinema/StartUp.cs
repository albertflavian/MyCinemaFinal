﻿


using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;

using Owin;

[assembly: OwinStartup(typeof(MyCinema.Startup))]

namespace MyCinema
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
          
        }
    }
}