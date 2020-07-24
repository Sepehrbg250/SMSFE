using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace SMSFE.Models
{
    public class Cola_Enviro_MailContext : DbContext
    {
        public Cola_Enviro_MailContext (DbContextOptions<Cola_Enviro_MailContext> options): base(options)
        {
        
        }
        public DbSet<Cola_Envio_Mail> Cola_Envio_Mail { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Cola_Envio_Mail>().ToTable("Cola_Envio_Mail");
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.EnableSensitiveDataLogging(true);
        //}
    }

}
