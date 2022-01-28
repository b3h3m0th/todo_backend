using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDo_Backend.Model
{
    public class ToDoDAL_MySQL
    {
        private static readonly ToDosContext _context = new ToDosContext();

        public IEnumerable<ToDo> GetToDos()
        {
            return _context.ToDos;
        }

        public ToDo GetToDo(int id)
        {
            return _context.ToDos.SingleOrDefault(t => t.ID == id);
        }

        public IEnumerable<ToDo> GetToDosWithDeadlineWithin(int days)
        {
            return _context.ToDos.Where(t => t.Deadline.Date.CompareTo(DateTime.Today.AddDays(days)) <= 0);
        }

        public void AddToDo(ToDo newTodo)
        {
            _context.ToDos.Add(newTodo);
            _context.SaveChanges();
        }

        public void UpdateToDo(ToDo updatedToDo)
        {
            ToDo oldToDo = _context.ToDos.SingleOrDefault(t => t.ID == updatedToDo.ID);
            if (oldToDo != null)
            {
                oldToDo.Beschreibung = updatedToDo.Beschreibung;
                oldToDo.Titel = updatedToDo.Titel;
                oldToDo.Deadline = updatedToDo.Deadline;
                oldToDo.Erledigt = updatedToDo.Erledigt;
                _context.SaveChanges();
            }
        }

        public void DeleteToDo(int id)
        {
            ToDo todo = _context.ToDos.SingleOrDefault(t => t.ID == id);
            if (todo != null)
            {
                _context.ToDos.Remove(todo);
                _context.SaveChanges();
            }
        }
    }
}