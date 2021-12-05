using System.Collections.Generic;

namespace DevGames.Api.Entities
{
    public class Board
    {
        public Board(string gameTitle, string description, string rules)
        {
            GameTitle = gameTitle;
            Description = description;
            Rules = rules;

            Posts = new List<Post>();
        }

        public int Id { get; set; }
        public string GameTitle { get; private set; }
        public string Description { get; private set; }
        public string Rules { get; private set; }
        public List<Post> Posts { get; private set; }

        public void Update(string description, string rules)
        {
            Description = description;
            Rules = rules;
        }

        public void AddPost(Post post)
        {
            Posts.Add(post);
        }

    }
}