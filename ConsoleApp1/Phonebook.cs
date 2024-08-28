using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Phonebook
    {
        private static List<Abonent> abonents = new List<Abonent>();

        private static Phonebook instance;
        private Phonebook()
        {
            ReadFile();
        }

        public void StorePhonebook()
        {
            var stringAbonents = "";
            foreach (var abonent in abonents)
            {
                stringAbonents += $"{abonent.Name} {abonent.NumberPhone}\n";
            }
            File.WriteAllText("phonebook.txt", stringAbonents);
        }

        public static void ReadFile()
        {
            File.AppendAllText("phonebook.txt", "");
            FileInfo fi1 = new FileInfo("phonebook.txt");
            using (StreamReader sr = fi1.OpenText())
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    string[] person = s.Split(' ');
                    Abonent abonent = new Abonent();
                    abonent.Name = person[0];
                    abonent.NumberPhone = int.Parse(person[1]);
                    abonents.Add(abonent);
                }
            }
        }

        public static Phonebook getInstance()
        {
            if (instance == null)
            {
                instance = new Phonebook();
            }
            return instance;
        }

        public void AddAbonent(Abonent abonent)
        {
            if(abonents.Any(x => x.Name == abonent.Name || x.NumberPhone == abonent.NumberPhone))
            {
                Console.WriteLine("Такого абонента не существует");
            }
            else
            {
                abonents.Add(abonent);
            }
        }

        public void RemoveAbonent(string name) 
        {
            Abonent remove = new Abonent();
            foreach (var person in abonents)
            {
                if(person.Name == name)
                {
                    remove = person;
                }
            }
            abonents.Remove(remove);
        }

        public Abonent SearchAbonent(long number)
        {
            foreach (var person in abonents)
            {
                if (person.NumberPhone == number)
                {
                    Console.WriteLine(person.Name + " " + person.NumberPhone);
                    return person;
                }
            }
            Console.WriteLine("Такого абонента не существует");
            return null;
        }

        public Abonent SearchAbonent(string name)
        {
            foreach (var person in abonents)
            {
                if (person.Name == name)
                {
                    Console.WriteLine(person.Name + " " + person.NumberPhone);
                    return person;
                }
            }
            Console.WriteLine("Такого абонента не существует");
            return null;
        }


    }
}
