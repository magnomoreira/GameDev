using Microsoft.AspNetCore.Mvc;

namespace DevGames.Api.Controllers
{
    [Route("api/boards/{id}/posts")]
    [ApiController]
    public class PostController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}