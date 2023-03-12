using Microsoft.AspNetCore.Mvc;

namespace todo.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {

        [HttpGet("/")]
        public string Get()
        {
            return "Hello world! Congrats, the controller is working.";
        }

    }
}
