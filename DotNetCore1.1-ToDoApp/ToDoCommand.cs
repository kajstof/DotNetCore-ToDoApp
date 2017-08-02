using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoApp
{
    
    class ToDoCommand
    {
        public ToDoAction Action { get; set; }
        public string TaskName { get; set; }

        public ToDoCommand(string command)
        {
            if (!(command.Length >= 2 && command.Substring(0, 2) == "--"))
            {
                TaskName = command.Length > 1 ? command.Substring(1) : null;
                command = command.Length > 0 ? command.Substring(0, 1) : null;
            }

            switch (command)
            {
                case "+":
                    Action = ToDoAction.Add;
                    break;
                case "-":
                    Action = ToDoAction.Remove;
                    break;
                case "--":
                    Action = ToDoAction.Clear;
                    break;
                case "q":
                    Action = ToDoAction.Quit;
                    break;
                default:
                    Action = ToDoAction.Unknown;
                    break;
            }
        }
    }
}
