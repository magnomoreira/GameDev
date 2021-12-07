using System.Collections.Generic;
using System.Linq;
using DevGames.Api.Entities;

namespace DevGames.Api.Persistence.Repositories
{
    public class BoardRepository: IBoardRepository
    {
        private readonly DevGamesContext _context;

        public BoardRepository(DevGamesContext context)
        {
            _context = context;
        }
        public IEnumerable<Board> GetAll()
        {
            return _context.Boards.ToList();
        }

        public Board GetById(int id)
        {
            var response = _context.Boards.SingleOrDefault(p => p.Id == id);
            return response;
        }

        public void Add(Board board)
        {
            _context.Boards.Add(board);
            _context.SaveChanges();
        }

        public void Update(Board board)
        {
            
            _context.Update(board);
            _context.SaveChanges();
        }
    }
}