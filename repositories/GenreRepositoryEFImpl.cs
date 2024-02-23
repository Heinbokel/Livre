using Livre.configurations;
using Livre.models;
using Microsoft.EntityFrameworkCore;

namespace Livre.repositories {

    /// <summary>
    /// Entity Framework Implementation of the IGenresRepository.
    /// </summary>
    /// <author>Bob Heinbokel</author>
    public class GenresRepositoryEFImpl : IGenresRepository
    {

        private readonly LivreDbContext _context;

        /// <summary>
        /// Constructor for dependency injection.
        /// </summary>
        /// <param name="context">The LivreDbContext to use.</param>
        public GenresRepositoryEFImpl(LivreDbContext context) {
            this._context = context;
        }

        ///<inheritdoc/>
        public List<Genre> GetGenresByIds(List<int> ids) {
            return this._context.Genres.Where(genre => ids.Contains(genre.Id)).ToList();
        }

    }

}