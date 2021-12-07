using System.Linq;
using AutoMapper;
using DevGames.Api.Entities;
using DevGames.Api.Model;
using DevGames.Api.Persistence;
using DevGames.Api.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevGames.Api.Controllers
{
    [Route("api/boards/{id}/posts")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _repository;
        private readonly IMapper _mapper;
        
        public PostController(IPostRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult GetAll(int id)
        {
            var post = _repository.GetAllByBoard(id);
            return Ok(post);
        }

        [HttpGet("{postId}")]
        public IActionResult GetById(int id, int postId)
        {
            var post = _repository.GetById(id,postId);
            if (post == null) return NotFound();
            return Ok(post);
        }

        [HttpPost]
        public IActionResult Post(int id, AddPostInputModel model)
        {
            var posts = new Post(model.Title,model.Description, id);
            _repository.Add(posts);
            return CreatedAtAction(nameof(GetById), new {id = id , postId = posts.Id}, model);
        }

        
        [HttpPost("{postId}/comments")]
        public IActionResult PostComment(int id , int postId, AddCommentInputModel model)
        {
            var postsExist = _repository.GetById(id, postId);
            
            if (postsExist == null) return NotFound();

            var comments = new Comment(model.Title, model.Description, model.User, postId);
            
            _repository.AddComment(comments);
            
            return NoContent();
        }
    }
}