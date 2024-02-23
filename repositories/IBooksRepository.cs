using Livre.models;

namespace Livre.repositories {

    /// <summary>
    /// Interface representing the contract all Book Repositories must follow.
    /// </summary>
    /// <author>Bob Heinbokel</author>
    public interface IBooksRepository {

        /// <summary>
        /// Retrieves the entire list of books available.
        /// </summary>
        /// <returns>The complete list of books to return.</returns>
        public List<Book> GetBooks();

        /// <summary>
        /// Retrieves a list of books matching the sent in criteria. For example, criteria could match the Title, ISBN, or publication date.
        /// </summary>
        /// <param name="criteria">The criteria to search on.</param>
        /// <returns>The list of books matching the sent in criteria.</returns>
        public List<Book> GetBooksByCriteria(string criteria);

        /// <summary>
        /// Retrieves a single book by its ID (or null if not found).
        /// </summary>
        /// <param name="id">The ID of the book.</param>
        /// <returns>The single book with the matching ID, or null.</returns>
        public Book? GetBookById(int id);

        /// <summary>
        /// Creates a book and saves it to the database with the given parameters.
        /// </summary>
        /// <param name="title">The book's title.</param>
        /// <param name="synopsis">The book's synopsis.</param>
        /// <param name="isbn">The book's ISBN.</param>
        /// <param name="publicationDate">The book's publication date.</param>
        /// <param name="authorIds">The book's author Id's.</param>
        /// <param name="genreIds">The book's genre Id's.</param>
        /// <returns>The created book, with its generated ID included.</returns>
        public Book CreateBook(string title, string synopsis, string isbn, DateOnly publicationDate, List<int> authorIds, List<int> genreIds);

        /// <summary>
        /// Updates a book and saves it to the database with the given parameters.
        /// </summary>
        /// <param name="id">The ID of the book to update.</param>
        /// <param name="title">The book's title.</param>
        /// <param name="synopsis">The book's synopsis.</param>
        /// <param name="isbn">The book's ISBN.</param>
        /// <param name="publicationDate">The book's publication date.</param>
        /// <param name="authorIds">The book's author Id's.</param>
        /// <param name="genreIds">The book's genre Id's.</param>
        public void UpdateBook(int id, string title, string synopsis, string isbn, DateOnly publicationDate, List<int> authorIds, List<int> genreIds);

        /// <summary>
        /// Deletes a book from the database with the given ID.
        /// </summary>
        /// <param name="id">The ID of the book to delete.</param>
        public void DeleteBook(int id);

    }

}