using AutoMapper;
using DevGames.Api.Entities;
using DevGames.Api.Model;
using DevGames.Api.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DevGames.Api.Controllers
{
    [Route("api/[controller]")]
    public class BoardsController : ControllerBase
    {
        private readonly IBoardRepository _repository;
        private readonly IMapper _mapper;

        public BoardsController(IBoardRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var response = _repository.GetAll();
            return Ok(response);

        }

        [HttpGet("id")]
        public IActionResult GetBYId(int id)
        {
            var response = _repository.GetById(id);
            if (Response == null) return NotFound();
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post( AddBoardInputModel model)
        {
            var responseBoard = _mapper.Map<Board>(model);
             _repository.Add(responseBoard);
            return CreatedAtAction("GetById", new {id = responseBoard.Id}, model);
        }

        [HttpPut("id")]
        public IActionResult Put(int id, UpdateBoardInputModel model)
        {
            var board = _repository.GetById(id);
            if (board == null) return NotFound();
            board.Update(model.Description, model.Rules);
            _repository.Update(board);
            return NoContent();
        }
    }
}