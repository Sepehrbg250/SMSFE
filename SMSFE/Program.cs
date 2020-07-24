using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using SMSFE.Models;

namespace SMSFE
{
    public class Program
    {
        public static IConfiguration Configuration;
        private static ILog Log;
        public static void Main(string[] args)
        {
            try
            {
                var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
                XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
                Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                CreateHostBuilder(args).Build().Run();
                Log.Info("Log Repository built and connected to database server.");
            }
            catch(Exception ex) { Log.Error("Connection to database or logger config failed:" + ex); }
        }
        
        public static string GetConnectionString()
        {            
            var server = Configuration.GetSection("DbConfig").GetSection("DbServer").Value;
            var port = Configuration.GetSection("DbConfig").GetSection("DbPort").Value;
            var user = Configuration.GetSection("DbConfig").GetSection("DbUser").Value;
            var password = Configuration.GetSection("DbConfig").GetSection("DbPassword").Value;
            var database = Configuration.GetSection("DbConfig").GetSection("Database").Value;
            return ($"Server={server},{port};Initial Catalog={database};User ID = {user}; Password={password};");
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    IConfiguration configuration = hostContext.Configuration;
                    Configuration = configuration;
                    var optionsBuilder = new DbContextOptionsBuilder<Cola_Enviro_MailContext>();
                    optionsBuilder.UseSqlServer(GetConnectionString());
                    services.AddScoped<Cola_Enviro_MailContext>(s => new Cola_Enviro_MailContext(optionsBuilder.Options));
                    services.AddHostedService<Worker>();
                    
                    
                });
            
    }
}
