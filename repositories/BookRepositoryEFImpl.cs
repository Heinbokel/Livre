using Livre.configurations;
using Livre.models;
using Microsoft.EntityFrameworkCore;

namespace Livre.repositories {

    /// <summary>
    /// Entity Framework Implementation of the IBooksRepository.
    /// </summary>
    /// <author>Bob Heinbokel</author>
    public class BookRepositoryEFImpl : IBooksRepository
    {

        private readonly LivreDbContext _context;

        /// <summary>
        /// Constructor for dependency injection.
        /// </summary>
        /// <param name="context">The LivreDbContext to use.</param>
        public BookRepositoryEFImpl(LivreDbContext context) {
            this._context = context;
        }

        ///<inheritdoc/>
        public List<Book> GetBooks()
        {
            // Returns all books in our database. 
            // The Includes are optional, you could just retrieve the base book data only if you wanted.
            return this._context.Books
            .Include(books => books.Authors) // This tells it to retrieve the authors for each book as well.
            .Include(books => books.Genres) // This tells it to retrieve the genres for each book as well.
            .Include(books => books.BookImages) // This tells it to retrieve the images for each book as well.
            .ToList();
        }

        ///<inheritdoc/>
        public List<Book> GetBooksByCriteria(string criteria)
        {
            string searchTerm = criteria.ToUpper();

            return this._context.Books
            // INCLUDE ALL child data
            .Where(books => books.ISBN.ToUpper().Contains(searchTerm) || books.Title.ToUpper().Contains(searchTerm) || books.PublicationDate.ToString().Contains(searchTerm))
            .ToList();
        }

        ///<inheritdoc/>
        public Book? GetBookById(int id)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public Book CreateBook(string title, string synopsis, string isbn, DateOnly publicationDate, List<Author> authors, List<Genre> genres, List<BookImage> bookImages)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public void UpdateBook(string id, string title, string synopsis, string isbn, DateOnly publicationDate, List<Author> authors, List<Genre> genres, List<BookImage> bookImages)
        {
            throw new NotImplementedException();
        }

        ///<inheritdoc/>
        public void DeleteBook(string id)
        {
            throw new NotImplementedException();
        }

    }

}