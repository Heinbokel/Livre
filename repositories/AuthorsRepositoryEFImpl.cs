using Livre.configurations;
using Livre.models;
using Microsoft.EntityFrameworkCore;

namespace Livre.repositories {

    /// <summary>
    /// Entity Framework Implementation of the IAuthorsRepository.
    /// </summary>
    /// <author>Bob Heinbokel</author>
    public class AuthorsRepositoryEFImpl : IAuthorsRepository
    {

        private readonly LivreDbContext _context;

        /// <summary>
        /// Constructor for dependency injection.
        /// </summary>
        /// <param name="context">The LivreDbContext to use.</param>
        public AuthorsRepositoryEFImpl(LivreDbContext context) {
            this._context = context;
        }

        ///<inheritdoc/>
        public List<Author> GetAuthorsByIds(List<int> ids) {
            return this._context.Authors.Where(author => ids.Contains(author.Id)).ToList();
        }

    }

}