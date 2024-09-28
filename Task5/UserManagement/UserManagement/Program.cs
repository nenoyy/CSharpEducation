using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace UserManagement
{
  internal class Program
  {
    static void Main(string[] args)
    {
      UserManager userManager = new UserManager();
      while (true)
      {
        PrintMenu();
        switch (Console.ReadLine())
        {
            case ("1"):
            {
              try
              {
                Console.WriteLine("Введите ID");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите имя");
                string name = Console.ReadLine();
                Console.WriteLine("Введите email");
                string email = Console.ReadLine();
                User user = new User(id, name, email);
                userManager.AddUser(user);
              }
              catch(UserAlreadyExistsException ex)
              {
                Console.WriteLine(ex.Message);
              }
              catch
              {
                Console.WriteLine("Произошла непредвиденная ошибка");
              }
              break;
            }

            case ("2"):
            {
              try
              {
                Console.WriteLine("Введите ID");
                int id = int.Parse(Console.ReadLine());
                userManager.RemoveUser(id);
                break;
              }
              catch (UserNotFoundException ex) 
              { 
                Console.WriteLine(ex.Message);
              }
              catch
              {
                Console.WriteLine("Произошла непредвиденная ошибка");
              }
              break;
            }

            case("3"):
            {
              try
              {
                Console.WriteLine("Введите ID");
                int id = int.Parse(Console.ReadLine());
                User user = userManager.GetUser(id);
                Console.WriteLine($"ID: {user.Id}\n  Имя: {user.Name}\n  Email: {user.Email}");
              }
              catch (UserNotFoundException ex)
              {
                Console.WriteLine(ex.Message);
              }
              catch
              {
                Console.WriteLine("Произошла непредвиденная ошибка");
              }
              break;
            }

            case ("4"):
            {
              try
              {
                List<User> users = userManager.ListUsers();
                foreach (var item in users)
                {
                  Console.WriteLine($"ID: {item.Id}\nИмя: {item.Name}\nEmail: {item.Email}\n\n");
                }
              }
              catch
              {
                Console.WriteLine("Произошла непредвиденная ошибка");
              }
              break;
            }

            case("5"):
            {
              Environment.Exit(0);
              break;
            }
            
        }
          
      }
    }

    private static void PrintMenu()
    {
      Console.WriteLine("Выберите действие:\n" +
        "1. Добавить пользователя\n" +
        "2. Удалить пользователя\n" +
        "3. Найти пользователя\n" +
        "4. Вывести всех пользователей\n" +
        "5. Выход\n");
    }
  }
}
