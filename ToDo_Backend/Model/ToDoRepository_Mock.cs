using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDo_Backend.Model
{
    public class ToDoRepository_Mock : IToDoRepository
    {
        private List<ToDo> _aufgaben = new List<ToDo>()
        {
            new ToDo()
            {
                ID = 1,
                Titel = "Webservice fertig implementieren",
                Beschreibung = "Alle CRUD-Operatioen umsetzen",
                Deadline = new DateTime(2022, 01, 31),
                Erledigt = false
            },
            new ToDo()
            {
                ID = 2,
                Titel = "Mathe lernen",
                Beschreibung = "Sollte man eh immer machen :)",
                Deadline = new DateTime(2022, 04, 20),
                Erledigt = false
            }
        };

        public IEnumerable<ToDo> GetToDos()
        {
            return _aufgaben;
        }

        public ToDo GetToDo(int id)
        {
            return _aufgaben.SingleOrDefault(t => t.ID == id);
        }

        public IEnumerable<ToDo> GetToDosWithDeadlineWithin(int days)
        {
            return _aufgaben.Where(t => t.Deadline.Date.CompareTo(DateTime.Today.AddDays(days)) <= 0);
        }

        public void AddToDo(ToDo newTodo)
        {
            if (_aufgaben.Count == 0)
                newTodo.ID = 1;
            else newTodo.ID = _aufgaben.Max(t => t.ID) + 1;

            _aufgaben.Add(newTodo);
        }

        public void UpdateToDo(ToDo updatedToDo)
        {
            ToDo oldToDo = _aufgaben.SingleOrDefault(t => t.ID == updatedToDo.ID);
            if (oldToDo != null)
            {
                oldToDo.Beschreibung = updatedToDo.Beschreibung;
                oldToDo.Titel = updatedToDo.Titel;
                oldToDo.Deadline = updatedToDo.Deadline;
                oldToDo.Erledigt = updatedToDo.Erledigt;
                oldToDo.VerfasserID = updatedToDo.VerfasserID;
            }
        }

        public void DeleteToDo(int id)
        {
            ToDo todo = _aufgaben.SingleOrDefault(t => t.ID == id);
            if (todo != null)
            {
                _aufgaben.Remove(todo);
            }
        }
    }
}