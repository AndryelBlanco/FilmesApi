using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase   
    {
        private static List<MovieData> ListOfMovies = new List<MovieData>();


        //Padrão de verbo
        [HttpPost]
        public void addMovie([FromBody] MovieData movie) //FromBody diz que o movie vem do corpo da requisição
        {
            ListOfMovies.Add(movie);
        }
    }
}
