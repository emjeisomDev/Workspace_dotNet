using Microsoft.AspNetCore.Mvc;
using todo.Data;
using todo.Models;

namespace todo.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {

        [HttpGet("/")]
        public IActionResult GetAll([FromServices] DataContext context)
            => Ok(context.Todos.ToList());

        [HttpGet("/{id:int}")]
        public IActionResult GetById([FromRoute] int id, [FromServices] DataContext context)
        {
            var todos = context.Todos.FirstOrDefault(x => x.Id == id);
            if (todos == null)
                return NotFound();

            return Ok(todos);
        }
        

    }
}
