using Livre.models;
using Livre.models.requests;
using Livre.repositories;

namespace Livre.services {

    public class AuthorsService {

        private readonly IAuthorsRepository _authorsRepository;
        private readonly IBooksRepository _booksRepository;

        public AuthorsService(IAuthorsRepository authorsRepository, IBooksRepository booksRepository) {
            this._authorsRepository = authorsRepository;
            this._booksRepository = booksRepository;
        }

        /// <summary>
        /// Retrieves the list of authors matching the given criteria.
        /// If no criteria is provided, returns all authors.
        /// </summary>
        /// <param name="criteria">The criteria to search on.</param>
        /// <returns>The list of authors to return.</returns>
        public List<Author> GetAuthors(string? criteria) {
            return this._authorsRepository.GetAuthors();
        }

        /// <summary>
        /// Retrieves the author with the given ID (or null if not found).
        /// </summary>
        /// <param name="authorId">The author ID to look up.</param>
        /// <returns>The author to return.</returns>
        public Author? GetAuthorByAuthorId(int authorId) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Retrieves the genres for an author.
        /// </summary>
        /// <param name="authorId">The author ID to look up.</param>
        /// <returns>The list of genres to return.</returns>
        public List<Genre> GetGenresForAuthor(int authorId) {
            // Find the books the author has written.

            // Return the genres of those books.
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates an author in the database from the given request.
        /// </summary>
        /// <param name="request">The request to create an author from.</param>
        /// <returns>The Created Author with its generated ID.</returns>
        public Author CreateAuthor(AuthorCreateRequest request) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the author with the given ID and request.
        /// </summary>
        /// <param name="request">The request to update the author with.</param>
        /// <param name="authorId">The ID of the author.</param>
        public void UpdateAuthor(AuthorCreateRequest request, int authorId) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the author with the given ID.
        /// </summary>
        /// <param name="authorId">The ID to look up.</param>
        public void DeleteAuthor(int authorId) {
            throw new NotImplementedException();
        }

    }

}