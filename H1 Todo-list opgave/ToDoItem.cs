using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H1_Todo_list_opgave
{
    internal class ToDoItem
    {
        public DateTime Created { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsDone { get; set; }
        public bool IsFavorite { get; set; }
        public string? ToDoTitle { get; set; }
        public string? ToDo { get; set; }
        public long Repeat { get; set; } //If repeat > 0 then repeat is on
    }
}
