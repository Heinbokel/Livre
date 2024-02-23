using Livre.configurations;
using Livre.models;
using Livre.models.requests;
using Livre.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Livre.controllers {

    [ApiController]
    public class BooksController: ControllerBase {
        
        private readonly BooksService _booksService;

        public BooksController(BooksService booksService) {
            this._booksService = booksService;
        }

        [HttpGet("books", Name = "GetBooks")]
        public List<Book> GetBooks([FromQuery] string? criteria) {
            return this._booksService.GetBooks(criteria);
        }

        [HttpGet("books/{bookId}", Name = "GetBookById")]
        public Book? GetBookById(int bookId) {
            return this._booksService.GetBookByBookId(bookId);
        }

        [HttpPost("books", Name = "CreateBook")]
        public Book CreateBook([FromBody] BookCreateRequest request) {
            return this._booksService.CreateBook(request);
        }

        [HttpPut("books/{bookId}", Name = "UpdateBook")]
        public void UpdateBook([FromBody] BookCreateRequest request, int bookId) {
            this._booksService.UpdateBook(request, bookId);
        }

        [HttpDelete("books/{bookId}", Name = "DeleteBook")]
        public void DeleteBook(int bookId) {
            this._booksService.DeleteBook(bookId);
        }

    }

}