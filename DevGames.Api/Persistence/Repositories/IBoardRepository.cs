using System.Collections.Generic;
using DevGames.Api.Entities;

namespace DevGames.Api.Persistence.Repositories
{
    public interface IBoardRepository
    {
        IEnumerable<Board> GetAll();
        Board GetById(int id);
        void Add(Board board);
        void Update(Board board);
    }
}