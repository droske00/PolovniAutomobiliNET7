using Microsoft.EntityFrameworkCore;
using PolovniAutomobili.Data;

namespace PolovniAutomobili
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Definisemo koja SQL konekcija da se koristi i ka kom serveru.
            builder.Services.AddDbContextPool<PolovniAutomobiliDbContext>(options =>
                {
                options.UseSqlServer(builder.Configuration["PolovniAutomobiliDbConn"]);
                }
            );

            // Add services to the container.
            builder.Services.AddScoped<IAutomobilData, SqlCarData>(); //Mapiranje da podatke klase zameni sa podacima Interfejsa pogledati jos jednom i proguglati.
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}