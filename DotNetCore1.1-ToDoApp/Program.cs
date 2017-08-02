using System;
using System.Collections.Generic;

namespace DotNetCore1._1_ToDoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> toDoList = new List<string>();
            string option = null;
            string taskName = null;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("===========================================================");
            Console.WriteLine("ToDoApp | DotNetCore 1.1 | Copyright 2017 Krzysztof Krysiak");
            Console.WriteLine("===========================================================");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("How use program: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("+name    | Add item");
            Console.WriteLine("-name    | Remove item");
            Console.WriteLine("--       | Clear list");
            Console.WriteLine("q        | Quit program");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("===========================================================");

            while (option != "q")
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Your option: ");
                option = Console.ReadLine();
                if (!(option.Length >= 2 && option.Substring(0, 2) == "--"))
                {
                    taskName = option.Length > 1 ? option.Substring(1) : null;
                    option = option.Length > 0 ? option.Substring(0, 1) : null;
                }

                Console.ForegroundColor = ConsoleColor.DarkGray;
                switch (option)
                {
                    case "+":
                        if (toDoList.Contains(taskName))
                        {
                            Console.WriteLine($"Item \"{taskName}\" exists in To Do List");
                        }
                        else
                        {
                            toDoList.Add(taskName);
                            Console.WriteLine($"Item \"{taskName}\" added to list");
                        }
                        break;
                    case "-":
                        if (toDoList.Contains(taskName))
                        {
                            toDoList.Remove(taskName);
                            Console.WriteLine($"Item \"{taskName}\" removed from list");
                        }
                        else
                        {
                            Console.WriteLine($"Item \"{taskName}\" not exists in To Do List");
                        }
                        break;
                    case "--":
                        toDoList.Clear();
                        Console.WriteLine("To Do List cleared");
                        break;
                    default:
                        Console.WriteLine("Unknown option");
                        break;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Items in To Do List: {{ {string.Join(", ", toDoList)} }}");
            }
        }
    }
}