using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoServicoSaude.Migrations
{
    public partial class classesbase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Pessoa_PessoaId",
                table: "Endereco");

            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_TipoEndereco_TipoEnderecoId",
                table: "Endereco");

            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "Pessoa",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Alergia",
                table: "Pessoa",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Altura",
                table: "Pessoa",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Pessoa",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "DoencaHereditaria",
                table: "Pessoa",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mecanografico",
                table: "Pessoa",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NIF",
                table: "Pessoa",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumeroBeneficiario",
                table: "Pessoa",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Peso",
                table: "Pessoa",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegistroProfissional",
                table: "Pessoa",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TipoEnderecoId",
                table: "Endereco",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PessoaId",
                table: "Endereco",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "NomeEndereco",
                table: "Endereco",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Contacto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telemovel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Site = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Principal = table.Column<bool>(type: "bit", nullable: false),
                    PessoaId = table.Column<int>(type: "int", nullable: true),
                    TipoContactoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacto_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contacto_TipoContacto_TipoContactoId",
                        column: x => x.TipoContactoId,
                        principalTable: "TipoContacto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mecanografico = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Moeda = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provincia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Provincia_Pais_PaisId",
                        column: x => x.PaisId,
                        principalTable: "Pais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Municipio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinciaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Municipio_Provincia_ProvinciaId",
                        column: x => x.ProvinciaId,
                        principalTable: "Provincia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacto_PessoaId",
                table: "Contacto",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacto_TipoContactoId",
                table: "Contacto",
                column: "TipoContactoId");

            migrationBuilder.CreateIndex(
                name: "IX_Municipio_ProvinciaId",
                table: "Municipio",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Provincia_PaisId",
                table: "Provincia",
                column: "PaisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Pessoa_PessoaId",
                table: "Endereco",
                column: "PessoaId",
                principalTable: "Pessoa",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_TipoEndereco_TipoEnderecoId",
                table: "Endereco",
                column: "TipoEnderecoId",
                principalTable: "TipoEndereco",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Pessoa_PessoaId",
                table: "Endereco");

            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_TipoEndereco_TipoEnderecoId",
                table: "Endereco");

            migrationBuilder.DropTable(
                name: "Contacto");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Municipio");

            migrationBuilder.DropTable(
                name: "Provincia");

            migrationBuilder.DropTable(
                name: "Pais");

            migrationBuilder.DropColumn(
                name: "Activo",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "Alergia",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "Altura",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "DoencaHereditaria",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "Mecanografico",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "NIF",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "NumeroBeneficiario",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "Peso",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "RegistroProfissional",
                table: "Pessoa");

            migrationBuilder.AlterColumn<int>(
                name: "TipoEnderecoId",
                table: "Endereco",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PessoaId",
                table: "Endereco",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NomeEndereco",
                table: "Endereco",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Pessoa_PessoaId",
                table: "Endereco",
                column: "PessoaId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_TipoEndereco_TipoEnderecoId",
                table: "Endereco",
                column: "TipoEnderecoId",
                principalTable: "TipoEndereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
