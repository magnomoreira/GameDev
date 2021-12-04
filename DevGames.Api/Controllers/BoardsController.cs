using System.Linq;
using AutoMapper;
using DevGames.Api.Entities;
using DevGames.Api.Model;
using DevGames.Api.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DevGames.Api.Controllers
{
    [Route("api/[controller]")]
    public class BoardsController : ControllerBase
    {
        private readonly DevGamesContext _devGamesContext;
        private readonly IMapper _mapper;

        public BoardsController(DevGamesContext devGamesContext, IMapper mapper)
        {
            _devGamesContext = devGamesContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_devGamesContext.Boards);

        }

        [HttpGet("id")]
        public IActionResult GetBYId(int id)
        {
            var responseBoardId = _devGamesContext.Boards.SingleOrDefault(i => i.Id == id);
            if (responseBoardId == null) return NotFound();
            return Ok(responseBoardId);
        }

        [HttpPost]
        public IActionResult Post(AddBoardInputModel model)
        {
            var responseBoard = _mapper.Map<Board>(model);
            _devGamesContext.Boards.Add(responseBoard);
            return CreatedAtAction("GetById", new {id = model.Id}, model);
        }

        [HttpPut("id")]
        public IActionResult Put(int id, UpdateBoardInputModel model)
        {
            var responseBoardId = _devGamesContext.Boards.SingleOrDefault(i => i.Id == id);
            if (responseBoardId == null) return NotFound();
            responseBoardId.Update(model.Description, model.Rules);
            return NoContent();
        }
    }
}