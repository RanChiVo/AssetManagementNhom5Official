﻿using System;
using Abp;
using Abp.Collections.Extensions;
using Abp.Dependency;
using Castle.Facilities.Logging;
using Abp.Castle.Logging.Log4Net;
using Abp.PlugIns;

namespace GSoft.AbpZeroTemplate.Migrator
{
    public class Program
    {
        private static bool _skipConnVerification;

        [STAThread]
        public static void Main(string[] args)
        {
            ParseArgs(args);

            using (var bootstrapper = AbpBootstrapper.Create<AbpZeroTemplateMigratorModule>())
            {
                bootstrapper.IocManager.IocContainer
                    .AddFacility<LoggingFacility>(f => f.UseAbpLog4Net()
                        .WithConfig("log4net.config")
                    );

                bootstrapper.Initialize();

                using (var migrateExecuter = bootstrapper.IocManager.ResolveAsDisposable<MultiTenantMigrateExecuter>())
                {
                    migrateExecuter.Object.Run(_skipConnVerification);
                }

                if (_skipConnVerification) return;
                
                Console.WriteLine("Press ENTER to exit...");
                Console.ReadLine();
            }
        }

        private static void ParseArgs(string[] args)
        {
            if (args.IsNullOrEmpty())
            {
                return;
            }

            foreach (var arg in args)
            {
                if (arg == "-s")
                {
                    _skipConnVerification = true;
                }
            }
        }
    }
}
