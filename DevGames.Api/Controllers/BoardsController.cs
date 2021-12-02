using DevGames.Api.Model;
using Microsoft.AspNetCore.Mvc;

namespace DevGames.Api.Controllers
{
    [Route("api/[controller")]
    public class BoardsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            return NoContent();

        }

        [HttpGet("id")]
        public IActionResult GetBYId(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(AddBoardInputModel model)
        {
            return CreatedAtAction("GetById", new {id = model.Id}, model);
        }

        [HttpPut("id")]
        public IActionResult Put(int id, UpdateBoardInputModel model)
        {
            return NoContent();
        }

        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}