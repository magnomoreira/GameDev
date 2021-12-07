using System.Collections.Generic;
using System.Linq;
using DevGames.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevGames.Api.Persistence.Repositories
{
    public class PostRepository: IPostRepository
    {
        private readonly DevGamesContext _context;

        public PostRepository(DevGamesContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Post> GetAllByBoard(int boardId)
        {
            var response = _context.Posts.Where(p => p.Id == boardId);
            return response;
        }

        public Post GetById(int id, int postId)
        {
            var response = _context
                .Posts
                .Include(p => p.Comments)
                .SingleOrDefault(p => p.Id == postId);
            return response;
        }

        public void Add(Post post)
        {
            _context.Add(post);
            _context.SaveChanges();
        }

        public void AddComment(Comment comment)
        {
            _context.Add(comment);
            _context.SaveChanges();
            
            
        }
    }
}