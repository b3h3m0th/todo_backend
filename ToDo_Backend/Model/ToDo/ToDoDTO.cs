using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo_Backend.Model
{
    public class ToDoDTO
    {
        public int ID { get; set; }

        public string Titel { get; set; }

        public string Beschreibung { get; set; }

        public DateTime Deadline { get; set; }

        public bool Erledigt { get; set; }

        public int VerfasserID { get; set; }
    }
}
