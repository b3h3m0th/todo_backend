using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo_Backend.Model;

namespace ToDo_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDosController : ControllerBase
    {
        private IToDoRepository _repository;

        public ToDosController(IToDoRepository todoRepository)
        {
            _repository = todoRepository;
        }

        // GET: api/todos
        // GET: api/todos?deadlineWithinDays=:deadlineWithinDays
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<ToDoDTO>> GetToDos([FromQuery] int? deadlineWithinDays)
        {
            if (deadlineWithinDays != null)
                return Ok(_repository.GetToDosWithDeadlineWithin(deadlineWithinDays.Value));

            return Ok(_repository.GetToDos());
        }

        // ACHTUNG: Action-Methoden müssen sich inder URL und/oder der HTTP-Methode unterscheiden, Querystring allein reicht nicht!

        // POST api/todos?deadlineWithinDays=:days
        //[HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public ActionResult<IEnumerable<ToDo>> GetToDosWithinDeadline(int deadlineWithinDays)
        //{
        //    return Ok(ToDoDAL_Mock.GetToDosWithDeadlineWithin(deadlineWithinDays));
        //}

        // GET: api/todos/:id
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ToDoDTO> GetToDo([FromRoute] int id)
        {
            ToDo todo = _repository.GetToDo(id);

            if (todo == null) return NotFound();

            return Ok(todo);
        }

        // POST: api/todos
        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ToDoDTO> AddToDo([FromBody] ToDoDTO newTodo)
        {
            if (newTodo == null || newTodo.ID != 0)
                return BadRequest();

            _repository.AddToDo(new ToDo()
            {
                ID = newTodo.ID,
                Titel = newTodo.Titel,
                Beschreibung = newTodo.Beschreibung,
                Deadline = newTodo.Deadline,
                Erledigt = newTodo.Erledigt,
                VerfasserID = newTodo.VerfasserID
            });

            return CreatedAtAction(nameof(GetToDo), new { id = newTodo.ID }, newTodo);
        }

        // PUT: api/todos/:id
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ToDoDTO> UpdateToDo([FromRoute] int id, [FromBody] ToDoDTO updatedToDo)
        {
            ToDo todoDB = _repository.GetToDo(id);

            if (todoDB == null)
                return NotFound();

            if (updatedToDo == null || id != updatedToDo.ID || updatedToDo.VerfasserID != todoDB.VerfasserID)
                return BadRequest();

            _repository.UpdateToDo(new ToDo()
            {
                ID = updatedToDo.ID,
                Titel = updatedToDo.Titel,
                Beschreibung = updatedToDo.Beschreibung,
                Deadline = updatedToDo.Deadline,
                Erledigt = updatedToDo.Erledigt,
                VerfasserID = todoDB.VerfasserID
            });

            return Ok(updatedToDo);
        }

        // DELETE: api/todos/:id
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteToDo([FromRoute] int id)
        {
            if (_repository.GetToDo(id) == null)
                return NotFound();

            _repository.DeleteToDo(id);
            return NoContent();
        }
    }
}