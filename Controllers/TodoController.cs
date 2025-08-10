using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Dto;
using TodoApp.Models;
using TodoApp.Services;

namespace TodoApp.Controllers
{
    [Route("api/todos")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private TodoService _todoService;
        public TodoController(TodoService todoService)
        {
            _todoService = todoService;
        }

        /// <summary>
        /// Get All Todos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> GetAll()
        {
            var result = await _todoService.GetAll();
            return Ok(result);
        }

        /// <summary>
        /// Get a single todo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Todo>> GetTodo(int id)
        {
            var todo = await _todoService.GetTodo(id);
            return Ok(todo);
        }

        /// <summary>
        /// Creates a todo 
        /// </summary>
        /// <param name="todoItem"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Todo>> CreateTodo([FromBody] TodoDto todoItem)
        {
            var created = await _todoService.CreateTodoItem(todoItem);
            return CreatedAtAction(nameof(GetTodo), new {id = created.Id}, created);
        }

        /// <summary>
        /// Replaces a todo, full update
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Todo>> PutTodo(int id, [FromBody] TodoDto dto)
        {
            var update = await _todoService.UpdateTodo(id, dto);
            return Ok(update);
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult<Todo>> PatchTodo(int id, [FromBody] TodoPatchDto dto)
        {
            var updated = await _todoService.PatchTodo(id, dto);
            return Ok(updated);
        }

        /// <summary>
        /// Deletes a specific todo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            var removed = await _todoService.DeleteTodo(id);
            return NoContent();
        }

    }
}
