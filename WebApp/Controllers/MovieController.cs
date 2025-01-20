using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using WebApp.Models.Movies;
using Movie = WebApp.Models.Movies.Movie;

namespace WebApp.Controllers
{
    public class MovieController : Controller
    {
        private readonly MoviesContext _context;

        public MovieController(MoviesContext context)
        {
            _context = context;
        }
        
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 10)
        {
            var movies = _context.Movies.AsQueryable();

            var paginatedList = await PaginatedList<Movie>.CreateAsync(movies, pageNumber, pageSize);

            return View(paginatedList);
        }
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .Include(m => m.MovieCasts)
                .ThenInclude(mc => mc.Person)
                .FirstOrDefaultAsync(m => m.MovieId == id);

            if (movie == null)
            {
                return NotFound();
            }

            if (_inMemoryCast.ContainsKey(movie.MovieId))
            {
                movie.MovieCasts = movie.MovieCasts
                    .Concat(_inMemoryCast[movie.MovieId])
                    .ToList();
            }
            

            return View(movie);
        }
        private static Dictionary<int, List<MovieCast>> _inMemoryCast = new Dictionary<int, List<MovieCast>>();
        
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MovieId,Title,Budget,Homepage,Overview,Popularity,ReleaseDate,Revenue,Runtime,MovieStatus,Tagline,VoteAverage,VoteCount")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }
        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MovieId,Title,Budget,Homepage,Overview,Popularity,ReleaseDate,Revenue,Runtime,MovieStatus,Tagline,VoteAverage,VoteCount")] Movie movie)
        {
            if (id != movie.MovieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.MovieId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddToCast(MovieCast movieCast)
        {
            if (ModelState.IsValid)
            {
                int movieId = movieCast.MovieId;

                if (!_inMemoryCast.ContainsKey(movieId))
                {
                    _inMemoryCast[movieId] = new List<MovieCast>();
                }

                _inMemoryCast[movieId].Add(movieCast);

                return RedirectToAction("Details", new { id = movieId });
            }

            ViewBag.MovieId = movieCast.MovieId;
            return View(movieCast);
        }
        public IActionResult AddToCast(int id)
        {
            // Przekazujemy ID filmu do widoku
            ViewBag.MovieId = id;
            return View();
        }
        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.MovieId == id);
        }
    }
}
