using IntergalacticRaceLeague.DAL;
using IntergalacticRaceLeague.BLL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using IntergalacticRaceLeague.Models;

namespace IntergalacticRaceLeague
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<RaceLeagueContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<RaceLeagueContext>()
                  
                  .AddDefaultTokenProviders();

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<RacerRepository>();
            builder.Services.AddScoped<RacerService>();

            builder.Services.AddScoped<VehicleRepository>();
            builder.Services.AddScoped<VehicleService>();

            builder.Services.AddScoped<TournamentRepository>();
            builder.Services.AddScoped<TournamentService>();

            builder.Services.AddScoped<RacerTournamentRepository>();
            builder.Services.AddScoped<RacerTournamentService>();
            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
          

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                DbInitializer.SeedUsersAndRoles(services).Wait();
            }
            app.Run();
        }
    }
}