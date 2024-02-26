using Livre.configurations;
using Livre.models;
using Livre.models.requests;
using Livre.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Livre.controllers {

    [ApiController]
    public class AuthorsController: ControllerBase {
        
        private readonly AuthorsService _authorsService;

        public AuthorsController(AuthorsService authorsService) {
            this._authorsService = authorsService;
        }

        [HttpGet("authors", Name = "GetAuthors")]
        public List<Author> GetAuthors() {
            return this._authorsService.GetAuthors(null);
        }

    }

}