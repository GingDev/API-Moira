using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;
using System.IO;

namespace MoiraSoft
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateWebHostBuilder(args).Build().Run();
            //CreateWebHostBuilder(args).Build().Run();
            var appBasePath = Directory.GetCurrentDirectory();
            NLog.GlobalDiagnosticsContext.Set("appbasepath", appBasePath);
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            try
            {
                logger.Debug("init main");
                BuildWebHost(args).Run();
            }
            catch (Exception ex)
            {
                //NLog: catch setup errors
                logger.Error(ex, "Stopped program because of exception");
                throw;
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                NLog.LogManager.Shutdown();
            }
        }

        //public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)
        //        .UseStartup<Startup>();
        public static IWebHost BuildWebHost(string[] args) =>
    WebHost.CreateDefaultBuilder(args)

    //.ConfigureAppConfiguration((webHostBuilderContext, configurationBuilder) => {

    //    var hostingEnvironment = webHostBuilderContext.HostingEnvironment;
    //    configurationBuilder.AddConfigServer(hostingEnvironment);
    //})
    .UseContentRoot(Directory.GetCurrentDirectory())
    .UseUrls("http://+:5000/")
    .UseIISIntegration()
    .UseStartup<Startup>()
    .ConfigureLogging(logging =>
    {
        logging.ClearProviders();
        logging.SetMinimumLevel(LogLevel.Trace);
        //logging.AddDynamicConsole();
    }).UseNLog()
    .Build();
    }
}
