﻿using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace GSoft.AbpZeroTemplate.Web.Startup
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return new WebHostBuilder()
                .UseKestrel(opt => opt.AddServerHeader = false)
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>();
        }
    }
}
