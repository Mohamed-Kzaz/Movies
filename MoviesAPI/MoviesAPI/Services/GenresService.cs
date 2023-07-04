using Microsoft.EntityFrameworkCore;
using MoviesAPI.Models;

namespace MoviesAPI.Services
{
    public class GenresService : IGenresService
    {
        private readonly ApplicationDbContext _dbContext;

        public GenresService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Genre> Add(Genre genre)
        {
            await _dbContext.Genres.AddAsync(genre);

            _dbContext.SaveChanges();

            return genre;
        }

        public Genre Delete(Genre genre)
        {
            _dbContext.Remove(genre);
            _dbContext.SaveChanges();
            return genre;
        }

        public async Task<IEnumerable<Genre>> GetAll()
        {
            return await _dbContext.Genres.OrderBy(g => g.Name).ToListAsync();
        }

        public async Task<Genre> GetById(byte id)
        {
            return await _dbContext.Genres.SingleOrDefaultAsync(g => g.Id == id);
        }

        public Task<bool> IsValidGenre(byte id)
        {
            return _dbContext.Genres.AnyAsync(g => g.Id == id);
        }

        public Genre Update(Genre genre)
        {
            _dbContext.Update(genre);
            _dbContext.SaveChanges();
            return genre;
        }
    }
}
