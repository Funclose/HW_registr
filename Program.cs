using Microsoft.EntityFrameworkCore;

namespace Hw_registr
{
     class Program
    {
        static void Main(string[] args)
        {
            DataBaseService dbService = new DataBaseService();
            dbService.EnsurePopulate();

            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Регистрация");
            Console.WriteLine("2. Авторизация");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RegistrService.RegisterUser();
                    break;
                case "2":
                    AuthorizationService.AuthorizeUser();
                    break;
                default:
                    Console.WriteLine("Некорректный выбор.");
                    break;
            }
        }
    }

    public class Registration
    { 
        public int Id { get; set; }
        public string Login { get; set; }

        public string Password { get; set; }
    }

    //public class Authorization
    //{
        
    //}


    public class ApplicationContext : DbContext
    {
        public DbSet<Registration> Registrations { get; set; } = null;
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-Q2JP8KP;Database=Motel;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
    public class DataBaseService
    { 
        public void EnsurePopulate()
        {
            using (var db = new ApplicationContext()) 
            { 
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
        }
    }


}
