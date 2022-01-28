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
        private ToDoDAL_MySQL _dal = new ToDoDAL_MySQL();
        // GET: api/todos
        // GET: api/todos?deadlineWithinDays=:deadlineWithinDays
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<ToDo>> GetToDos([FromQuery] int? deadlineWithinDays)
        {
            if (deadlineWithinDays != null)
                return Ok(_dal.GetToDosWithDeadlineWithin(deadlineWithinDays.Value));

            return Ok(_dal.GetToDos());
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
        public ActionResult<ToDo> GetToDo([FromRoute] int id)
        {
            ToDo todo = _dal.GetToDo(id);

            if (todo == null) return NotFound();

            return Ok(todo);
        }

        // POST: api/todos
        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ToDo> AddToDo([FromBody] ToDo newTodo)
        {
            if (newTodo == null || newTodo.ID != 0)
                return BadRequest();

            _dal.AddToDo(newTodo);
            return CreatedAtAction(nameof(GetToDo), new { id = newTodo.ID }, newTodo);
        }

        // PUT: api/todos/:id
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ToDo> UpdateToDo([FromRoute] int id, [FromBody] ToDo updatedToDo)
        {
            if (updatedToDo == null || id != updatedToDo.ID)
                return BadRequest();

            if (_dal.GetToDo(id) == null)
                return NotFound();

            _dal.UpdateToDo(updatedToDo);
            return Ok(updatedToDo);
        }

        // DELETE: api/todos/:id
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteToDo([FromRoute] int id)
        {
            if (_dal.GetToDo(id) == null)
                return NotFound();

            _dal.DeleteToDo(id);
            return NoContent();
        }
    }
}