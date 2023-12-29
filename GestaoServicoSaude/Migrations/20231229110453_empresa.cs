using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoServicoSaude.Migrations
{
    public partial class empresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Contacto");

            migrationBuilder.DropColumn(
                name: "Site",
                table: "Contacto");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Contacto");

            migrationBuilder.DropColumn(
                name: "Telemovel",
                table: "Contacto");

            migrationBuilder.AddColumn<bool>(
                name: "Cirurgia",
                table: "Pessoa",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CirurgiaDescricao",
                table: "Pessoa",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RecebeEmail",
                table: "Pessoa",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RecebeSMS",
                table: "Pessoa",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoSanguineo",
                table: "Pessoa",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Endereco",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PacienteId",
                table: "Endereco",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Contacto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Contacto",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MeioContacto",
                table: "Contacto",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NomeContacto",
                table: "Contacto",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PacienteId",
                table: "Contacto",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RazaoSocial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NIF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PacienteAlergia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alergia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacienteAlergia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PacienteAlergia_Pessoa_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pessoa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PacienteDoencaHereditaria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoencaHereditaria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PacienteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PacienteDoencaHereditaria", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PacienteDoencaHereditaria_Pessoa_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pessoa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_EmpresaId",
                table: "Endereco",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_PacienteId",
                table: "Endereco",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacto_EmpresaId",
                table: "Contacto",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacto_PacienteId",
                table: "Contacto",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_PacienteAlergia_PacienteId",
                table: "PacienteAlergia",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_PacienteDoencaHereditaria_PacienteId",
                table: "PacienteDoencaHereditaria",
                column: "PacienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacto_Empresa_EmpresaId",
                table: "Contacto",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacto_Pessoa_PacienteId",
                table: "Contacto",
                column: "PacienteId",
                principalTable: "Pessoa",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Empresa_EmpresaId",
                table: "Endereco",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Pessoa_PacienteId",
                table: "Endereco",
                column: "PacienteId",
                principalTable: "Pessoa",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacto_Empresa_EmpresaId",
                table: "Contacto");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacto_Pessoa_PacienteId",
                table: "Contacto");

            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Empresa_EmpresaId",
                table: "Endereco");

            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Pessoa_PacienteId",
                table: "Endereco");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "PacienteAlergia");

            migrationBuilder.DropTable(
                name: "PacienteDoencaHereditaria");

            migrationBuilder.DropIndex(
                name: "IX_Endereco_EmpresaId",
                table: "Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Endereco_PacienteId",
                table: "Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Contacto_EmpresaId",
                table: "Contacto");

            migrationBuilder.DropIndex(
                name: "IX_Contacto_PacienteId",
                table: "Contacto");

            migrationBuilder.DropColumn(
                name: "Cirurgia",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "CirurgiaDescricao",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "RecebeEmail",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "RecebeSMS",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "TipoSanguineo",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Contacto");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Contacto");

            migrationBuilder.DropColumn(
                name: "MeioContacto",
                table: "Contacto");

            migrationBuilder.DropColumn(
                name: "NomeContacto",
                table: "Contacto");

            migrationBuilder.DropColumn(
                name: "PacienteId",
                table: "Contacto");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Contacto",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Site",
                table: "Contacto",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Contacto",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telemovel",
                table: "Contacto",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
