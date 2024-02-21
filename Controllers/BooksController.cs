using Livre.configurations;
using Livre.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Livre.controllers {

    [ApiController]
    public class BooksController: ControllerBase {
        
        private readonly LivreDbContext _context;

        public BooksController(LivreDbContext livreDbContext) {
            this._context = livreDbContext;
        }

        [HttpGet("books", Name = "GetBooks")]
        public List<Book> GetBooks() {
            return this._context.Books
            .Include(b => b.Genres)
            .ToList();
        }

    }

}