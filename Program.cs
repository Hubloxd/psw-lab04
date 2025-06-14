using lab04.Data.Contexts;
using lab04.Data.Models;
using lab04.Forms.Admin;
using lab04.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace lab04
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; } = null!;

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
            ServiceProvider = services.BuildServiceProvider();
            
            // Aplikacja kliencka nie powinna tworzy� bazy danych ani migracji.
            // Migracje powinny by� stosowane przed uruchomieniem aplikacji klienckiej.
            try
            {
                // Sprawd� po��czenie z baz� danych
                var dbContext = ServiceProvider.GetRequiredService<DatabaseContext>();
                if (!dbContext.Database.CanConnect())
                {
                    Console.WriteLine("Database connection failed. Please check your connection string.");
                    MessageBox.Show($"B��d po��czenia z baz� danych", "B��d",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(1);
                }
                dbContext.Database.EnsureCreated();
                var userService = ServiceProvider.GetRequiredService<UserService>();
                if (!dbContext.Users.Any(u => u.Login == "admin"))
                {
                    var admin = new Data.Models.User
                    {
                        Password = "admin",
                        Email = "admin@admin.com",
                        FirstName = "Admin",
                        LastName = "Admin",
                        Login = "admin",
                        Permissions = 0,
                    };
                    userService.AddUser(admin, out _);
                }

                var loginForm = ServiceProvider.GetRequiredService<LoginForm>();
                Application.Run(loginForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"B��d: {ex.Message}", "B��d",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Metoda konfiguruj�ca us�ugi aplikacji, wykorzystuj�c dependency injection. Dodaj�c singletony us�ug.
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

            // Rejestracja us�ug
            services.AddScoped<UserService>();
            services.AddScoped<EventService>();
            services.AddScoped<RegistrationService>();

            // Rejestracja formularzy
            services.AddTransient<LoginForm>();
            services.AddTransient<RegisterForm>();
            services.AddTransient<AdminManageUsersForm>();
        }
    }
}