
namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var phonebook = Phonebook.getInstance();
            bool check = true;
            while (check)
            {
                Console.WriteLine("Нажмите соответствующую клавишу:\n" +
                    "1. Добавить абонент\n" +
                    "2. Удалить абонент\n" +
                    "3. Поиск абонента по имени\n" +
                    "4. Поиск абонента по номеру\n" +
                    "5. Выход\n");

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine("Введите имя абонента");
                        string nameAbonent = Console.ReadLine();
                        Console.WriteLine("Введите номер абонента");
                        long numberAbonent = long.Parse(Console.ReadLine());

                        var abonent = new Abonent
                        {
                            Name = nameAbonent,
                            NumberPhone = numberAbonent
                        };

                        phonebook.AddAbonent(abonent);
                        break;

                    case ConsoleKey.D2:
                        Console.WriteLine("Введите имя абонента");
                        string nameRemove = Console.ReadLine();
                        phonebook.RemoveAbonent(nameRemove); 
                        break;

                    case ConsoleKey.D3:
                        Console.WriteLine("Введите имя абонента");
                        string name = Console.ReadLine();
                        phonebook.SearchAbonent(name);
                        break;

                    case ConsoleKey.D4:
                        Console.WriteLine("Введите номер абонента");
                        int number = int.Parse(Console.ReadLine());
                        phonebook.SearchAbonent(number);
                        break;

                    case ConsoleKey.D5:
                        phonebook.StorePhonebook();
                        check = false;
                        break;
                }
            }
            
        }
    }
}