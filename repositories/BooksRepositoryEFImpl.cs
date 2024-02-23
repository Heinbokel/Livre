using Livre.configurations;
using Livre.models;
using Livre.models.requests;
using Microsoft.EntityFrameworkCore;

namespace Livre.repositories {

    /// <summary>
    /// Entity Framework Implementation of the IBooksRepository.
    /// </summary>
    /// <author>Bob Heinbokel</author>
    public class BooksRepositoryEFImpl : IBooksRepository
    {

        private readonly LivreDbContext _context;

        /// <summary>
        /// Constructor for dependency injection.
        /// </summary>
        /// <param name="context">The LivreDbContext to use.</param>
        public BooksRepositoryEFImpl(LivreDbContext context) {
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
            .Include(books => books.Authors) // This tells it to retrieve the authors for each book as well.
            .Include(books => books.Genres) // This tells it to retrieve the genres for each book as well.
            .Include(books => books.BookImages) // This tells it to retrieve the images for each book as well.
            // .Where filters our books to only include the books that match the conditions.
            .Where(books => books.ISBN.ToUpper().Contains(searchTerm) || books.Title.ToUpper().Contains(searchTerm) || books.PublicationDate.ToString().Contains(searchTerm))
            .ToList();
        }

        ///<inheritdoc/>
        public Book? GetBookById(int id)
        {
            return this._context.Books
            .Include(books => books.Authors) // This tells it to retrieve the authors for each book as well.
            .Include(books => books.Genres) // This tells it to retrieve the genres for each book as well.
            .Include(books => books.BookImages) // This tells it to retrieve the images for each book as well.
            .Where(book => book.Id == id) // Return the book that has the sent in ID
            .FirstOrDefault(); // This will return the single found book, or null if not found.
        }

        ///<inheritdoc/>
        public Book CreateBook(string title, string synopsis, string isbn, DateOnly publicationDate, List<int> authorIds, List<int> genreIds)
        {
            Book bookToCreate = new Book
            {
                Title = title,
                Synopsis = synopsis,
                ISBN = isbn,
                PublicationDate = publicationDate,
                CreatedByUserId = 0, // We don't have any USER's yet or the ability to make users so we'll just throw 0 in here for now.
                CreatedDateTime = DateTime.Now
            };

            // Attach supporting book details such as authors and genres.
            AttachSupportingBookDetails(authorIds, genreIds, bookToCreate);

            // Save our changes to the database (this also adds the generated Id to our bookToCreate).
            this._context.Books.Add(bookToCreate);
            this._context.SaveChanges();

            return bookToCreate;
        }

        ///<inheritdoc/>
        public void UpdateBook(int id, string title, string synopsis, string isbn, DateOnly publicationDate, List<int> authorIds, List<int> genreIds)
        {
            Book? bookToUpdate = this.GetBookById(id);

            if (bookToUpdate != null) {
                bookToUpdate.Title = title;
                bookToUpdate.Synopsis = synopsis;
                bookToUpdate.ISBN = isbn;
                bookToUpdate.PublicationDate = publicationDate;
                bookToUpdate.UpdatedByUserId = 0; // We don't have any USER's yet or the ability to make users so we'll just throw 0 in here for now.
                bookToUpdate.UpdatedDateTime = DateTime.Now;

                // Attach supporting book details such as authors and genres.
                AttachSupportingBookDetails(authorIds, genreIds, bookToUpdate);

                // Save our changes to the database (this also adds the generated Id to our bookToCreate).
                this._context.SaveChanges();
            } else {
                throw new Exception($"Book with ID {id} was not found. Could not update book.");
            }
        }

        ///<inheritdoc/>
        public void DeleteBook(int id)
        {
            Book? bookToDelete = this._context.Books.Where(book => book.Id == id).FirstOrDefault();
            if (bookToDelete != null) {
                this._context.Books.Remove(bookToDelete);
                this._context.SaveChanges();
            } else {
                throw new Exception($"Book with ID {id} was not found. Could not delete book.");
            }
        }

        /// <summary>
        /// Retrieves supporting book data needed to save to the database.
        /// </summary>
        /// <param name="authors">The author ID's to look up.</param>
        /// <param name="genres">The genre ID's to look up.</param>
        /// <param name="book">The book to add the data to.</param>
        private void AttachSupportingBookDetails(List<int> authorIds, List<int> genreIds, Book book)
        {
            book.Authors = this._context.Authors.Where(author => authorIds.Contains(author.Id)).ToList();
            book.Genres = this._context.Genres.Where(genre => genreIds.Contains(genre.Id)).ToList();
        }

    }

}