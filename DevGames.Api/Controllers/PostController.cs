using DevGames.Api.Model;
using Microsoft.AspNetCore.Mvc;

namespace DevGames.Api.Controllers
{
    [Route("api/boards/{id}/posts")]
    [ApiController]
    public class PostController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll(int id)
        {
            return Ok();
        }

        [HttpGet("{postId}")]
        public IActionResult GetById(int id, int postId)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(AddPostInputModel model, int id)
        {
            return CreatedAtAction(nameof(GetById), new {id = id , postId = model.Id}, model);
        }

        
        [HttpPost("{postId}/comments")]
        public IActionResult PostComment(int id , int postId, AddCommentInputModel model)
        {
            return NoContent();
        }
    }
}