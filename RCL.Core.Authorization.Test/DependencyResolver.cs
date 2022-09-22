﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RCL.Core.Authorization.Test
{
    public static class DependencyResolver
    {
        public static ServiceProvider ServiceProvider()
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddUserSecrets<TestProject>();
            IConfiguration Configuration = builder.Build();

            IServiceCollection services = new ServiceCollection();
            services.AddRCLCoreAuthTokenService(options => Configuration.Bind("Auth",options));
            
            return services.BuildServiceProvider();
        }
    }

    public class TestProject
    {
    }
}
