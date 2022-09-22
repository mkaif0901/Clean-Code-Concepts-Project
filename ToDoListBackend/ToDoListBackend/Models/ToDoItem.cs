using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoListBackend.Models
{
    public class ToDoItem
    {
        public string title { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public string category { get; set; }
        public string priority { get; set; }
        public string due_dates { get; set; }

    }
}