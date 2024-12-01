using ControleDeFornecedor._Repositorio;
using ControleDeFornecedor.Data;
using Microsoft.EntityFrameworkCore;

namespace ControleDeFornecedor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Certifique-se de que o arquivo appsettings.json é lido corretamente
            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            // Configuração do DbContext
            builder.Services.AddDbContext<BancoContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
            );

            // Registra o repositório com injeção de dependência
            builder.Services.AddScoped<IFornecedorRepositorio, FornecedorRepositorio>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
