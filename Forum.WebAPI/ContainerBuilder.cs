using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace Forum.WebAPI
{
    public class AutofacContainerBuilder
    {
        public static  IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<StartupBase>();
                });
        
        public void ConfigureContainer(ContainerBuilder containerBuilder) 
        {
            containerBuilder.RegisterType<ForumContext>();
        }
    }
}
