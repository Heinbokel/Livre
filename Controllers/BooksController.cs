using Livre.configurations;
using Livre.models;
using Livre.repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Livre.controllers {

    [ApiController]
    public class BooksController: ControllerBase {
        
        private readonly IBooksRepository _booksRepository;

        public BooksController(IBooksRepository booksRepository) {
            this._booksRepository = booksRepository;
        }

        [HttpGet("books", Name = "GetBooks")]
        public List<Book> GetBooks([FromQuery] string? criteria) {
            List<Book> books = [];
            if (criteria != null) {
                books = this._booksRepository.GetBooksByCriteria(criteria);
            } else {
                books = this._booksRepository.GetBooks();
            }
            return books;
        }

    }

}