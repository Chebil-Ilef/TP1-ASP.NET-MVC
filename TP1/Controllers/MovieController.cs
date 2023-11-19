﻿using Microsoft.AspNetCore.Mvc;
using TP1.Models;

namespace TP1.Controllers
{
    public class MovieController : Controller

    {

        public IEnumerable<Movie> getAllMovies()
        {
            var movies = new List<Movie>()
             {
            new Movie { Id = 0, Name="Movie 0", ReleaseDate = new DateTime(2001, 11,14)},
            new Movie { Id = 1, Name = "Movie 1", ReleaseDate = new DateTime(2005, 1, 15) },
            new Movie { Id = 2, Name = "Movie 2", ReleaseDate = new DateTime(2013, 5, 20) },
            new Movie { Id = 3, Name = "Movie 3", ReleaseDate = new DateTime(2009, 3, 10) }
            };
            return movies;
        }

        public IActionResult Index()
        {
            var movies = getAllMovies();
            return View(movies);

        }

        public IActionResult Edit(int id)
        {
            return Content("Test Id" + id);
        }

        /*[HttpGet("Movie/Release/{year}/{month}")]*/  /*methode attribute route*/
        public IActionResult ByRelease(int month, int year) {

            List<Movie> moviesByReleaseDate = new List<Movie>();
            var movies = getAllMovies();

            foreach (var movie in movies)
            {
                if (movie.ReleaseDate.Year == year && movie.ReleaseDate.Month == month)
                {
                    moviesByReleaseDate.Add(movie);
                }
            }
            ViewBag.Month = month;
            ViewBag.Year = year;

            return View(moviesByReleaseDate);
        }

        
    }
    
}
