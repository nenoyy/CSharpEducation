using static System.Net.Mime.MediaTypeNames;

namespace EmployeeAccountingSystem
{
  internal class Program
  {
    static void Main(string[] args)
    {
      var employeeManager = new EmployeeManager<Employee>();

      while (true) 
      {
        PrintMenu();
        switch (Console.ReadLine())
        {
          case ("1"):
            {
              Console.WriteLine("Введите имя:");
              var nameFullTimeEmployee = Console.ReadLine();
              Console.WriteLine("Введите зп:");
              var salaryFullTimeEmloyee = decimal.Parse(Console.ReadLine());

              var employeeFullTime = new FullTimeEmployee(nameFullTimeEmployee, salaryFullTimeEmloyee)
              {
                Name = nameFullTimeEmployee,
                BaseSalary = salaryFullTimeEmloyee,
              };
              employeeManager.Add(employeeFullTime);
              break;
            }

          case ("2"):
            {
              Console.WriteLine("Введите имя:");
              var namePartTimeEmployee = Console.ReadLine();
              Console.WriteLine("Введите зп:");
              var salaryPartTimeEmloyee = decimal.Parse(Console.ReadLine());
              Console.WriteLine("Введите часы:");
              var hoursPartTimeEmloyee = int.Parse(Console.ReadLine());

              var employeePartlTime = new PartTimeEmployee(namePartTimeEmployee, salaryPartTimeEmloyee, hoursPartTimeEmloyee)
              {
                Name = namePartTimeEmployee,
                BaseSalary = salaryPartTimeEmloyee,
                workingHours = hoursPartTimeEmloyee
              };
              employeeManager.Add(employeePartlTime);
              break;
            }
          case ("3"):
            {
              Console.WriteLine("Введите имя:");
              var nameEmployee = Console.ReadLine();
              var employee = employeeManager.Get(nameEmployee);
              Console.WriteLine($"Сотрудник {employee.Name} получает {employee.CalculateSalary()}");
              break;
            }
          case ("4"):
            {
              Console.WriteLine("Введите имя:");
              var nameEmployee = Console.ReadLine();
              Console.WriteLine("Введите зп:");
              var salaryEmloyee = decimal.Parse(Console.ReadLine());

              var option = employeeManager.Get(nameEmployee);
              if (option is PartTimeEmployee)
              {
                Console.WriteLine("Введите часы:");
                var hoursEmloyee = int.Parse(Console.ReadLine());
                var employee = new PartTimeEmployee(nameEmployee, salaryEmloyee, hoursEmloyee)
                {
                  Name = nameEmployee,
                  BaseSalary = salaryEmloyee,
                  workingHours = hoursEmloyee
                };
                employeeManager.Update(employee);
              }
              else if (option is FullTimeEmployee)
              {
                var employee = new FullTimeEmployee(nameEmployee, salaryEmloyee)
                {
                  Name = nameEmployee,
                  BaseSalary = salaryEmloyee
                };
                employeeManager.Update(employee);
              }
              break;
            }
          case ("5"):
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
        "1. Добавить полного сотрудника\n" +
        "2. Добавить частичного сотрудника\n" +
        "3. Получить информацию о сотруднике\n" +
        "4. Обновить данные сотрудника\n" +
        "5. Выйти\n");
    }
  }
}
