using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace universidad.Data.Migrations
{
    public partial class i : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "Tercero",
                columns: table => new
                {
                    Codigo = table.Column<string>(maxLength: 20, nullable: true),
                    Especialidad = table.Column<string>(maxLength: 20, nullable: true),
                    TerceroID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Apellido = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Estado = table.Column<bool>(nullable: false),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    Nombres = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tercero", x => x.TerceroID);
                });

          
             

        }

      
    }
}
