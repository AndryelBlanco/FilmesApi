using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;

namespace FilmesApi.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<CreateMovieDto, MovieData>();//Vai fazer o mapeamento para conversão, logo converte de CreateMovieDto -> MovieData
            CreateMap<MovieData, GetMovieDto>();
            CreateMap<UpdateMovieDto, MovieData>();
        }
    }
}
