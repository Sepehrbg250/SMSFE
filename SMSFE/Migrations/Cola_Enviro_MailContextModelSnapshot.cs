﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SMSFE.Models;

namespace SMSFE.Migrations
{
    [DbContext(typeof(Cola_Enviro_MailContext))]
    partial class Cola_Enviro_MailContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0-preview.7.20365.15");

            modelBuilder.Entity("SMSFE.Models.Cola_Envio_Mail", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("AttachName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Attachment")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CantidadIntentosEnvio")
                        .HasColumnType("int");

                    b.Property<string>("Enviado")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EsAlerta")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaInsercion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("From")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("IdAdjunto")
                        .HasColumnType("bigint");

                    b.Property<bool>("Mostrar")
                        .HasColumnType("bit");

                    b.Property<string>("RazonSocReceptor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rut_Emisor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rut_Receptor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoAdjunto")
                        .HasColumnType("int");

                    b.Property<string>("To")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cola_Envio_Mail");
                });
#pragma warning restore 612, 618
        }
    }
}
