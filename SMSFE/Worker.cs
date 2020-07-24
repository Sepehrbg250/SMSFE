using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using log4net;
using log4net.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SMSFE.Models;

namespace SMSFE
{
    public class Worker : BackgroundService
    {
        db database;
        public IConfiguration Configuration { get; }
        public static IServiceScopeFactory _serviceScopeFactory;
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        EmailEngine emailengine;
        public Worker(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
        public void Prep() 
        {
            try
            {
                PrepDB.PrepPopulation();
                emailengine = new EmailEngine();
                database = new db();
                log.Info("Database created successfully");
            }
            catch (Exception ex) { log.Error("Database error:" + ex.Message); }
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Prep();
            while (!stoppingToken.IsCancellationRequested)
            {
                var emails = database.GetAllEmails() ?? new List<Cola_Envio_Mail>();
                
                if (database.GetAllEmails().Count == 0)
                {
                    Console.WriteLine("No Emails in Database...");                    
                }
                else
                {
                    foreach (var email in emails)
                    {
                        emailengine.SendEmail(email);                        
                    }                                        
                }
                Thread.Sleep(int.Parse(Program.Configuration.GetSection("EmailConfig").GetSection("Interval").Value));

            }
        }
        
    }
}
