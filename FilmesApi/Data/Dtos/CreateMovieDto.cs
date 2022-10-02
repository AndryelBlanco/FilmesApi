using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos
{
    public class CreateMovieDto
    {
        [Required(ErrorMessage = "Movie Title cannot be null")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Movie Director cannot be null")]
        public string Director { get; set; }

        public string Genre { get; set; }

        [Range(1, 600)]
        public int Duration { get; set; }
    }
}
