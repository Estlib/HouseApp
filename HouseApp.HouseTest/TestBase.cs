using HouseApp.ApplicationServices.Services;
using HouseApp.Core.ServiceInterface;
using HouseApp.Data;
using HouseApp.HouseTest.Macros;
using HouseApp.HouseTest.Mock;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseApp.HouseTest
{
    public abstract class TestBase
    {
        protected IServiceProvider serviceProvider { get; }
        protected TestBase()
        {
            var services = new ServiceCollection();
            SetupServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        public void Dispose()
        {
        }

        protected T Svc<T>()
        {
            return serviceProvider.GetService<T>();
        }

        protected T Macro<T>() where T : IMacros
        {
            return serviceProvider.GetService<T>();
        }

        public virtual void SetupServices(IServiceCollection services)
        {
            /*var testHostingEnvironment = new MockHostingEnvironment();
            var builder = new WebHostBuilder()
            .Configure(app => { })
            .ConfigureServices(services =>
            {
                serviceProvider.AddSingleton<IHostingEnvironment>(testHostingEnvironment);
            });
            var server = new TARge21ShopContext(builder);*/

            services.AddScoped<IHousesServices, HousesServices>();
            services.AddScoped<IHostingEnvironment, MockIHostEnvironment>();

            services.AddDbContext<HouseAppContext>(x =>
            {
                x.UseInMemoryDatabase("TEST");
                x.ConfigureWarnings(e => e.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            });

            RegisterMacros(services);
        }

        private void RegisterMacros(IServiceCollection services)
        {
            var macroBaseType = typeof(IMacros);
            var macros = macroBaseType.Assembly.GetTypes()
                .Where(x => macroBaseType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);
            foreach (var macro in macros)
            {
                services.AddSingleton(macro);
            }
        }
    }
}
