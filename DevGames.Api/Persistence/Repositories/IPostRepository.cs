
using System.Collections.Generic;
using DevGames.Api.Entities;

namespace DevGames.Api.Persistence.Repositories
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetAllByBoard(int boardId);
        Post GetById(int id, int postId);
        void Add(Post post);
        void AddComment(Comment comment);
    }
}