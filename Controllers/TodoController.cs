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
            if (todo is null) return NotFound();
            return Ok(todo);
        }

        /// <summary>
        /// Creates a todo 
        /// </summary>
        /// <param name="todoItem"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateTodo(TodoDto todoItem)
        {
            var result = await _todoService.CreateTodoItem(todoItem);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTodo(int id)
        {
            var result = await _todoService.DeleteTodo(id);

            if (result == null)
                return NotFound();

            return NoContent();
        }

    }
}
