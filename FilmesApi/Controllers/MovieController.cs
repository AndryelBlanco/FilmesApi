using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase   
    {
        private MovieContext _context;
        private IMapper _mapper;

        public MovieController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Padrão de verbo
        [HttpPost]
        public IActionResult addMovie([FromBody] CreateMovieDto movie) //FromBody diz que o movie vem do corpo da requisição
        {
            MovieData movieToAdd = _mapper.Map<MovieData>(movie); // Chamamos a conversão

            _context.Movies.Add(movieToAdd);
            _context.SaveChanges();
            return CreatedAtAction(nameof(getMovieById), new {Id = movieToAdd.Id}, movie);
        }

        [HttpGet]
        public IActionResult getMovie()
        {
            return Ok(_context.Movies);
        }

        [HttpGet("{Id}")]
        public IActionResult getMovieById(int Id)
        {
            MovieData MovieToReturn = _context.Movies.FirstOrDefault(movie => movie.Id == Id);

            if(MovieToReturn != null)
            {
                GetMovieDto movieDto = _mapper.Map<GetMovieDto>(MovieToReturn);
                return Ok(movieDto);
            }

            return NotFound();
        }

        [HttpPut("{Id}")]
        public IActionResult updateMovie(int Id, [FromBody] UpdateMovieDto movietoUpdateDTO)
        {
            MovieData MovieToUpdate= _context.Movies.FirstOrDefault(movie => movie.Id == Id);
            if(MovieToUpdate == null)
            {
                return NotFound();
            }

            _mapper.Map(movietoUpdateDTO, MovieToUpdate);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{Id}")]
        public IActionResult deleteMovie(int Id)
        {
            MovieData MovieToDelete = _context.Movies.FirstOrDefault(movie => movie.Id == Id);
            if (MovieToDelete == null)
            {
                return NotFound();
            }

            _context.Remove(MovieToDelete);
            _context.SaveChanges();
            return NoContent();

        }
    }
}
