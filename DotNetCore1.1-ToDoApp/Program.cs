using System;
using System.Collections.Generic;

namespace ToDoApp
{
    enum ToDoAction
    {
        Add,
        Remove,
        Clear,
        Quit,
        Unknown
    }

    class Program
    {
        private static List<string> toDoList = new List<string>();

        static void Main(string[] args)
        {
            ShowConsoleApplicationHeader();
            StartApplication();
        }

        private static void StartApplication()
        {
            ToDoCommand toDoCommand = null;
            do
            {
                Console.Write("Your option: ");
                toDoCommand = new ToDoCommand(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.DarkGray;
                switch (toDoCommand.Action)
                {
                    case ToDoAction.Add:
                        AddItemToList(toDoCommand.TaskName);
                        break;
                    case ToDoAction.Remove:
                        RemoveItemFromList(toDoCommand.TaskName);
                        break;
                    case ToDoAction.Clear:
                        ClearList();
                        break;
                    default:
                        UnkownOption();
                        break;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Items in To Do List: {{ {string.Join(", ", toDoList)} }}");
                Console.ForegroundColor = ConsoleColor.White;
            } while (toDoCommand.Action != ToDoAction.Quit);
        }

        private static void UnkownOption()
        {
            Console.WriteLine("Unknown option");
        }

        private static void ClearList()
        {
            toDoList.Clear();
            Console.WriteLine("To Do List cleared");
        }

        private static void RemoveItemFromList(string taskName)
        {
            if (toDoList.Contains(taskName))
            {
                toDoList.Remove(taskName);
                Console.WriteLine($"Item \"{taskName}\" removed from list");
            }
            else
            {
                Console.WriteLine($"Item \"{taskName}\" not exists in To Do List");
            }
        }

        private static void AddItemToList(string taskName)
        {
            if (toDoList.Contains(taskName))
            {
                Console.WriteLine($"Item \"{taskName}\" exists in To Do List");
            }
            else
            {
                toDoList.Add(taskName);
                Console.WriteLine($"Item \"{taskName}\" added to list");
            }
        }

        private static void ShowConsoleApplicationHeader()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("===========================================================");
            Console.WriteLine("ToDoApp | DotNetCore 1.1 | Copyright 2017 Krzysztof Krysiak");
            Console.WriteLine("===========================================================");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("How use program: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("+item    | Add item");
            Console.WriteLine("-item    | Remove item");
            Console.WriteLine("--       | Clear list");
            Console.WriteLine("q        | Quit program");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("===========================================================");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
