using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMSFE.Models
{
    class PrepDB
    {
        public static void PrepPopulation() 
        {
            var scope = Worker._serviceScopeFactory.CreateScope();            
            Migrate(scope.ServiceProvider.GetService<Cola_Enviro_MailContext>());
            
        }
        public static void Migrate(Cola_Enviro_MailContext context) 
        {
            context.Database.Migrate();
        }
    }
}
