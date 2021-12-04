using System.Linq;
using AutoMapper;
using DevGames.Api.Entities;
using DevGames.Api.Model;
using DevGames.Api.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DevGames.Api.Controllers
{
    [Route("api/boards/{id}/posts")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly DevGamesContext _devGamesContext;
        private readonly IMapper _mapper;
        
        public PostController(DevGamesContext devGamesContext, IMapper mapper)
        {
            _devGamesContext = devGamesContext;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult GetAll(int id)
        {
            var responsePost = _devGamesContext.Boards.SingleOrDefault(i => i.Id == id);
            if (responsePost == null) return NotFound();
            
            return Ok(responsePost.Posts);
        }

        [HttpGet("{postId}")]
        public IActionResult GetById(int id, int postId)
        {
            var responsePost = _devGamesContext.Boards.SingleOrDefault(i => i.Id == id);
            if (responsePost == null) return NotFound();

            var posts = responsePost.Posts.SingleOrDefault(p => p.Id == id);
            if (posts == null) return NotFound();

            return Ok(posts);
        }

        [HttpPost]
        public IActionResult Post(AddPostInputModel model, int id)
        {
            var responsePost = _devGamesContext.Boards.SingleOrDefault(i => i.Id == id);
            if (responsePost == null) return NotFound();

            //var posts = new Post(model.Id, model.Title, model.Description);
            var posts = _mapper.Map<Post>(model);
            responsePost.AddPost(posts);
            return CreatedAtAction(nameof(GetById), new {id = id , postId = model.Id}, model);
        }

        
        [HttpPost("{postId}/comments")]
        public IActionResult PostComment(int id , int postId, AddCommentInputModel model)
        {
            var responsePost = _devGamesContext.Boards.SingleOrDefault(i => i.Id == id);
            if (responsePost == null) return NotFound();

            var posts = responsePost.Posts.SingleOrDefault(p => p.Id == id);
            if (posts == null) return NotFound();

            var comments = new Comment(model.Title, model.Description, model.User);
            posts.AddComments(comments);
            
            return NoContent();
        }
    }
}