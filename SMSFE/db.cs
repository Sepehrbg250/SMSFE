using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SMSFE.Models;

namespace SMSFE
{
    class db
    {
        
        private IServiceScope scope;
        private Cola_Enviro_MailContext dbContext;
        public db() 
        {
            scope = Worker._serviceScopeFactory.CreateScope();
            dbContext = scope.ServiceProvider.GetRequiredService<Cola_Enviro_MailContext>();
        }
        public List<Cola_Envio_Mail> GetAllEmails() 
        {
            return dbContext.Cola_Envio_Mail.ToList();                
        }
        
    }
}
