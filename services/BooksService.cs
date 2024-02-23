using Livre.models;
using Livre.models.requests;
using Livre.repositories;

namespace Livre.services {

    public class BooksService {

        private readonly IBooksRepository _booksRepository;

        public BooksService(IBooksRepository booksRepository) {
            this._booksRepository = booksRepository;
        }

        public List<Book> GetBooks(string? criteria) {
            List<Book> books = [];

            if (criteria != null) {
                books.AddRange(this._booksRepository.GetBooksByCriteria(criteria));
            } else {
                books.AddRange(this._booksRepository.GetBooks());
            }

            return books;
        }

        public Book? GetBookByBookId(int bookId) {
            return this._booksRepository.GetBookById(bookId);
        }

        public Book CreateBook(BookCreateRequest request)
        {
            return this._booksRepository.CreateBook(request.Title, request.Synopsis, request.ISBN, request.PublicationDate, request.AuthorIds, request.GenreIds);
        }

        public void UpdateBook(BookCreateRequest request, int bookId) {
            this._booksRepository.UpdateBook(bookId, request.Title, request.Synopsis, request.ISBN, request.PublicationDate, request.AuthorIds, request.GenreIds);
        } 

        public void DeleteBook(int bookId) {
            this._booksRepository.DeleteBook(bookId);
        }

    }

}