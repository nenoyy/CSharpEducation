using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] field = new string[9];
            SetValueArray(field);
            FieldOutput(field);
            bool isX = true;
            for(int i = 0; i < 9; i++)
            {
                Console.WriteLine(isX ? "ходит X" : "ходит O");
                Move(field, isX);
                if (Сombinations(field))
                {
                    if (isX)
                    {
                        Console.WriteLine("Победил X");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Победил O");
                        break;
                    }
                }
                if (isX) isX = false;
                else isX = true;
                if (i == 8)
                {
                    Console.WriteLine("Ничья!");
                }
            }
            Console.ReadKey();
        }

        public static void FieldOutput(string[] field)
        {
            Console.WriteLine("-------------");
            Console.Write("|");
            for (int i = 0; i < field.Length; i++)
            {
                if (i % 3 == 2)
                {
                    PrintColor(field[i]);
                    Console.WriteLine(" " + "|");
                    Console.WriteLine("-------------");
                    if(i != 8)
                      Console.Write("|");
                }
                else
                {
                    PrintColor(field[i]);
                    Console.Write(" " + "|");
                }
            }
        }

        public static void PrintColor(string field) 
        {
            Console.Write(" ");
            if (field == "X")
            {
                Console.BackgroundColor = ConsoleColor.Red;
            }
            else if (field == "O")
            {
                Console.BackgroundColor = ConsoleColor.Blue;
            }
            Console.Write(field);
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static void SetValueArray(string[] field)
        {
            for (int i = 0; i < field.Length; i++)
            {
                field[i] = (i + 1).ToString();
            }
        }

        public static void Move(string[] field, bool isX)
        {
            int move = 0;
            do
            {
                while (true)
                {
                   var parseExist = int.TryParse(Console.ReadLine(), out move);
                    if (parseExist == false || move < 1 || move > 9)
                    {
                        Console.WriteLine("Введены некорректные данные");
                        FieldOutput(field);
                    }
                    else break;
                }
                
                if (field[move - 1] == "X" || field[move - 1] == "O")
                {
                    Console.WriteLine("Вы выбрали заполненную ячейку");
                    FieldOutput(field);
                }
            }
            while (field[move - 1] == "X" || field[move - 1] == "O");
            if(isX)
            {
                field[move - 1] = "X";
            }
            else field[move - 1] = "O";
            FieldOutput(field);
        }

        public static bool Сombinations(string[] field)
        {
            if(field[0] == field[1] && field[0] == field[2] || field[0] == field[4] && field[0] == field[7])
                return true;
            else if(field[8] == field[7] && field[8] == field[6] || field[8] == field[5] && field[8] == field[2])
                return true;
            else if(field[4] == field[0] && field[4] == field[8] || field[4] == field[2] && field[4] == field[6] ||
                field[4] == field[1] && field[4] == field[7] || field[4] == field[3] && field[4] == field[5])
                return true;
            else return false;
        }
    }
}
