using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options) //Construtor da classe DBContext vai receber essas options
        {

        }

        //Conjunto de dados do banco
        public DbSet<MovieData> Movies { get; set; }

    }
}
