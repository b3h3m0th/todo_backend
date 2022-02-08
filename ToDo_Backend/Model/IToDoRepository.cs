using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo_Backend.Model
{
    public interface IToDoRepository
    {
        public IEnumerable<ToDo> GetToDos();

        public ToDo GetToDo(int id);

        public IEnumerable<ToDo> GetToDosWithDeadlineWithin(int days);

        public void AddToDo(ToDo newTodo);

        public void UpdateToDo(ToDo updatedToDo);

        public void DeleteToDo(int id);
    }
}
