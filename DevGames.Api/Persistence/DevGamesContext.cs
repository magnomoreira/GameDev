using System.Collections.Generic;
using DevGames.Api.Entities;

namespace DevGames.Api.Persistence
{
    public class DevGamesContext
    {
        public DevGamesContext()
        {
            Boards = new List<Board>();
        }
        
        public List<Board> Boards { get; private set; }
    }
}