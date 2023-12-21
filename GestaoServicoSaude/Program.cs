using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GestaoServicoSaude.Data;
using GestaoServicoSaude.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Context") ?? throw new InvalidOperationException("Connection string 'Context' not found.")));



// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<EnderecoService>();
builder.Services.AddScoped<TipoEnderecoService>();
builder.Services.AddScoped<TipoContactoService>();
builder.Services.AddScoped<ContactoService>();
builder.Services.AddScoped<FuncionarioService>();
builder.Services.AddScoped<MunicipioService>();
builder.Services.AddScoped<PacienteService>();
builder.Services.AddScoped<PaisService>();
builder.Services.AddScoped<ProfissionalSuadeService>();
builder.Services.AddScoped<ProvinciaService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
