﻿using Microsoft.EntityFrameworkCore;
using MovieShop.Core.Entities;
using MovieShop.Core.Models;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Infrastructure.Data;
using MovieShop.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Core.Repositories
{
    public class MovieRepository: EfRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext): base(dbContext)
        {
        }

        public async Task<IEnumerable<Movie>> GetHighestRevenueMovies()
        {
            var movies = await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(50).ToListAsync();
            return movies;
        }

        public Task<IEnumerable<Movie>> GetMoviesByGenre(int genreId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Movie>> GetTopRatedMovies()
        {
            throw new NotImplementedException();
        }

        public override async Task<Movie> GetByIdAsync(int id)
        {
            /**
            var movie = await _dbContext.Movies
                                        .Include(m => m.MovieCasts).ThenInclude(m => m.Cast).Include(m => m.MovieGenres)
                                        .ThenInclude(m => m.Genre)
                                        .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null) return null;
            var movieRating = await _dbContext.Reviews.Where(r => r.MovieId == id).DefaultIfEmpty()
                                              .AverageAsync(r => r == null ? 0 : r.Rating);
            if (movieRating > 0) movie.Rating = movieRating;
            return movie;
            **/
            throw new NotImplementedException();
        }

    }
}
