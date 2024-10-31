using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Models
{
    public class TodoItem
    {
        required public int Id { get; set; }
        required public string Task { get; set; }
        public bool IsCompleted { get; set; }
    }

}