using lab04.Data.Contexts;
using lab04.Data.Models;
using lab04.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace lab04
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();
            ConfigureServices(services);

            var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();

            using var dbContext = new DatabaseContext(optionsBuilder.Options);
            if (!dbContext.Database.CanConnect())
            {
                Console.WriteLine("Database connection failed. Please check your connection string.");
                return;
            }

            // Aplikacja kliencka nie powinna tworzyæ bazy danych ani migracji.
            // Migracje powinny byæ stosowane przed uruchomieniem aplikacji klienckiej.
            //if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != "Development")
            //{
            //    dbContext.Database.Migrate();
            //}
            //else
            //{
            //    dbContext.Database.EnsureCreated();
            //}

            // Add admin user if not exists
            if (!dbContext.Users.Any(u => u.Login == "admin"))
            {
                dbContext.Users.Add(new User
                {
                    Password = "admin",
                    Email = "admin@admin.com",
                    FirstName = "Admin",
                    LastName = "Admin",
                    Login = "admin",
                    Permissions = 0,
                });
                dbContext.SaveChanges();
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

        /// <summary>
        /// Metoda konfiguruj¹ca us³ugi aplikacji. Dodaj¹c singletony us³ug.
        /// </summary>
        /// <param name="services"></param>
        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>(options => 
                options.UseMySql(
                    "server=localhost;port=3306;user=root;password=root;database=Wydarzenia;",
                    new MariaDbServerVersion(
                        new Version(11, 4, 6)
            )));
        }
    }
}