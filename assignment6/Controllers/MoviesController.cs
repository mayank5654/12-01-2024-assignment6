using assignment6.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace assignment6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {

        private static List<MovieModel> movies = new List<MovieModel>();

        // GET: api/movies
        [HttpGet]
        public ActionResult<IEnumerable<MovieModel>> Get()
        {
            return Ok(movies);
        }

        // GET: api/movies/1
        [HttpGet("{id}")]
        public ActionResult<MovieModel> Get(int id)
        {
            var movie = movies.Find(m => m.Id == id);
            if (movie == null)
                return NotFound();

            return Ok(movie);
        }

        // POST: api/movies
        [HttpPost]
        public ActionResult<MovieModel> Post([FromBody] MovieModel newMovie)
        {
            newMovie.Id = movies.Count + 1;
            movies.Add(newMovie);
            return CreatedAtAction(nameof(Get), new { id = newMovie.Id }, newMovie);
        }

        // PUT: api/movies/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] MovieModel updatedMovie)
        {
            var existingMovie = movies.Find(m => m.Id == id);
            if (existingMovie == null)
                return NotFound();

            existingMovie.Title = updatedMovie.Title;
            existingMovie.Year = updatedMovie.Year;
            // Update other properties as needed

            return NoContent();
        }

        // DELETE: api/movies/1
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var movieToRemove = movies.Find(m => m.Id == id);
            if (movieToRemove == null)
                return NotFound();

            movies.Remove(movieToRemove);
            return NoContent();
        }
    }
}

