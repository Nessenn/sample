﻿using CustomerManager;

using Microsoft.Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace CustomerManager
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
