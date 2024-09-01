using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hw_registr;

namespace Hw_registr
{
    public static class AuthorizationService
    {
        private static void ShowMainMenu()
        {
            while (true)
            {
                Console.WriteLine("Главное меню:");
                Console.WriteLine("1. Опция 1");
                Console.WriteLine("2. Опция 2");
                Console.WriteLine("3. Выход");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        // Логика для Опции 1
                        break;
                    case "2":
                        // Логика для Опции 2
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Некорректный выбор, попробуйте снова.");
                        break;
                }
            }
        }
        public static void AuthorizeUser()
        {
            Console.Write("Введите логин: ");
            string login = Console.ReadLine();

            Console.Write("Введите пароль: ");
            string password = Console.ReadLine();

            using (var db = new ApplicationContext())
            {
                var user = db.Registrations.SingleOrDefault(u => u.Login == login);
                if (user != null && RegistrService.VerifyHashedPassword(user.Password, password))
                {
                    Console.WriteLine("Авторизация успешна!");
                    ShowMainMenu();
                }
                else
                {
                    Console.WriteLine("Неверный логин или пароль.");
                }
            }
        }
    }
}
