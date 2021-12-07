using AutoMapper;
using DevGames.Api.Entities;
using DevGames.Api.Model;

namespace DevGames.Api.Mappers
{
    public class BoardMappers : Profile
    {
        public BoardMappers()
        {
            CreateMap<AddBoardInputModel, Board>();
            CreateMap<AddPostInputModel, Post>();
        }
    }
}