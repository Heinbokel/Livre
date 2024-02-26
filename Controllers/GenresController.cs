using Livre.configurations;
using Livre.models;
using Livre.models.requests;
using Livre.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Livre.controllers {

    [ApiController]
    public class GenresController: ControllerBase {
        
        private readonly LivreDbContext _context;

        public GenresController(LivreDbContext context) {
            this._context = context;
        }

        [HttpGet("genres", Name = "GetGenres")]
        public List<Genre> GetGenres() {
            return this._context.Genres.ToList();
        }

    }

}