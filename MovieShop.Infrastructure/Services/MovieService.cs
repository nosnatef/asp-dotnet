using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MovieShop.Core.Models;
using MovieShop.Core.Models.Response;
using MovieShop.Core.Repositories;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Core.ServiceInterfaces;
using MovieShop.Infrastructure.Repositories;

namespace MovieShop.Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;

        // Constructor injection
        // Dependency injection enable us to write loosely coupled code
        public MovieService(IMovieRepository repository)
        {
            // create movieRepo instance in every method of my service class
            // newing up is convenient but we want to avoid
            // make sure you dont break any existing code

            _repository = repository;
        }
        /**
        public Task<MovieDetailsResponseModel> CreateMovie(MovieCreateRequest movieCreateRequest)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultSet<>> GetAllMoviePurchasesByPagination(int pageSize = 20, int page = 0)
        {
            throw new NotImplementedException();
        }

        public Task<PaginatedList<>> GetAllPurchasesByMovieId(int movieId)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultSet<>> GetMoviesByPagination(int pageSize = 20, int page = 0, string title = "")
        {
            throw new NotImplementedException();
        }

        public Task<MovieDetailsResponseModel> UpdateMovie(MovieCreateRequest movieCreateRequest)
        {
            throw new NotImplementedException();
        }
        **/

        public async Task<IEnumerable<MovieResponseModel>> GetHighestGrossingMovies()
        {
            
            var movies = await _repository.GetHighestRevenueMovies();
            var movieResponseModel = new List<MovieResponseModel>();
            foreach(var movie in movies)
            {
                movieResponseModel.Add(new MovieResponseModel
                {
                    Id = movie.Id, PosterUrl = movie.PosterUrl, ReleaseDate = (DateTime)movie.ReleaseDate, Title = movie.Title
                });
            }

            return movieResponseModel;
        }

        public Task<MovieDetailsResponseModel> GetMovieAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MovieResponseModel>> GetMoviesByGenre(int genreId)
        {
            throw new NotImplementedException();
        }

        

        public Task<int> GetMoviesCount(string title = "")
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReviewMovieResponseModel>> GetReviewsForMovie(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<MovieResponseModel>> GetTopRatedMovies()
        {
            throw new NotImplementedException();
        }

        
    }
}
