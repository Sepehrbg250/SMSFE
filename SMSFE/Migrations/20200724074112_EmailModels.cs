using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SMSFE.Migrations
{
    public partial class EmailModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cola_Envio_Mail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaInsercion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    From = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    To = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttachName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Attachment = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Enviado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoAdjunto = table.Column<int>(type: "int", nullable: false),
                    IdAdjunto = table.Column<long>(type: "bigint", nullable: false),
                    Rut_Emisor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rut_Receptor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RazonSocReceptor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EsAlerta = table.Column<bool>(type: "bit", nullable: false),
                    Mostrar = table.Column<bool>(type: "bit", nullable: false),
                    CantidadIntentosEnvio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cola_Envio_Mail", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cola_Envio_Mail");
        }
    }
}
