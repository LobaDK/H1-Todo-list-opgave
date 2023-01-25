using System;
using System.Reflection;

namespace H1_Todo_list_opgave
{
    internal class Program
    {
        static List<ToDoItem> todoTasks = new List<ToDoItem>();
        static internal void Main(string[] args)
        {
            Menu();
        }

        static internal void Menu()
        {
            while (true)
            {
                string menuResponse;
                do
                {
                    Console.Write("\n[E]exit\n[S]how Todo list\n[C]reate Todo task\n[R]ead Todo task from list\n[U]pdate Todo task\n[D]elete Todo task\n: ");
                    menuResponse = Console.ReadLine().ToLower();
                } while (menuResponse == null || (menuResponse != "e" && menuResponse != "s" && menuResponse != "c" && menuResponse != "r" && menuResponse != "u" && menuResponse != "d"));

                if (menuResponse == "s") ShowTodoList();
                else if (menuResponse == "c") CreateTodoTask();
                else if (menuResponse == "r") ReadTodoTask();
                else if (menuResponse == "u") UpdateTodoTask();
                else if (menuResponse == "d") DeleteTodoTask();
                else if (menuResponse == "e") break;
            }
        }

        private static void DeleteTodoTask()
        {
            ShowTodoList();
            if (todoTasks.Count > 0) todoTasks.RemoveAt(SelectIndex());
        }

        private static void UpdateTodoTask()
        {
            ShowTodoList();
            if (todoTasks.Count > 0)
            {
                int index = SelectIndex();
                Console.Write($"\nOld task name: {todoTasks[index].ToDoTitle}\nNew task name: ");
                todoTasks[index].ToDoTitle = Console.ReadLine();

                Console.Write($"\nOld task description: {todoTasks[index].ToDo}\nNew task description: ");
                todoTasks[index].ToDo = Console.ReadLine();

                long repeat;
                do
                {
                    Console.Write($"\nOld task repeat hourly interval: {todoTasks[index].Repeat}\nNew task repeat hourly interval: ");
                } while (!long.TryParse(Console.ReadLine(), out repeat));
                todoTasks[index].Repeat = repeat;

                string markAsFavorite;
                do
                {
                    Console.Write($"\nMarked as favorite: {todoTasks[index].IsFavorite}\nMark as favorite? Y/N: ");
                    markAsFavorite = Console.ReadLine().ToLower();
                } while (markAsFavorite == null || (markAsFavorite != "y" && markAsFavorite != "n"));

                int year;
                int month;
                int day;

                // Loop until year is an int
                Console.WriteLine($"\nOld deadline: {todoTasks[index].Deadline}");
                do
                {
                    Console.Write("\nDeadline year: ");
                } while (!int.TryParse(Console.ReadLine(), out year));
                // Loop until month is an int
                do
                {
                    Console.Write("\nDeadline month: ");
                } while (!int.TryParse(Console.ReadLine(), out month) || month > 12);
                // Loop until day is an int
                do
                {
                    Console.Write("\nDeadline day: ");
                } while (!int.TryParse(Console.ReadLine(), out day) || day > 31);

                // Assign a DateTime type to the task deadline using user-selected dates
                todoTasks[index].Deadline = new DateTime(year, month, day);
            }
        }

        private static void ReadTodoTask()
        {
            ShowTodoList();
            if (todoTasks.Count > 0)
            {
                int index = SelectIndex();
                Console.WriteLine($"\nTask name: {todoTasks[index].ToDoTitle}\nTask: {todoTasks[index].ToDo}\nScheduled at: {todoTasks[index].Deadline}\nCreated at: {todoTasks[index].Created}");
            }
        }

        private static void CreateTodoTask()
        {
            ToDoItem toDoItem = new();
            Console.Write("\nTask name: ");
            toDoItem.ToDoTitle = Console.ReadLine();

            Console.Write("\nTask description: ");
            toDoItem.ToDo = Console.ReadLine();

            long repeat;
            do
            {
                Console.Write("\nTask repeat hourly interval (0 for no repeat): ");
            } while (!long.TryParse(Console.ReadLine(), out repeat));
            toDoItem.Repeat = repeat;

            string markAsFavorite;
            do
            {
                Console.Write("\nMark as favorite? Y/N: ");
                markAsFavorite = Console.ReadLine().ToLower();
            } while (markAsFavorite == null || (markAsFavorite != "y" && markAsFavorite != "n"));

            int year;
            int month;
            int day;

            // Loop until year is an int
            do
            {
                Console.Write("\nDeadline year: ");
            } while (!int.TryParse(Console.ReadLine(), out year));
            // Loop until month is an int
            do
            {
                Console.Write("\nDeadline month: ");
            } while (!int.TryParse(Console.ReadLine(), out month) || month > 12);
            // Loop until day is an int
            do
            {
                Console.Write("\nDeadline day: ");
            } while (!int.TryParse(Console.ReadLine(), out day) || day > 31);

            // Assign a DateTime type to the task deadline using user-selected dates
            toDoItem.Deadline = new DateTime(year, month, day);

            toDoItem.Created= DateTime.Now;

            todoTasks.Add(toDoItem);
        }

        private static void ShowTodoList()
        {
            if (todoTasks.Count > 0)
            {
                for (int i = 0; i < todoTasks.Count; i++)
                {
                    Console.WriteLine($"[{i}] {todoTasks[i].ToDoTitle}");
                }
            }
            else Console.WriteLine("\nNo tasks available");
        }

        private static int SelectIndex()
        {
            int index;
            do
            {
                Console.Write("\nSelect task #: ");
            } while (!int.TryParse(Console.ReadLine(), out index) || index >= todoTasks.Count);

            return index;
        }
    }
}