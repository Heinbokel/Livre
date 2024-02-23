using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Livre.models {

    public class AuthorCreateRequest {

        [Required]
        [MinLength(1, ErrorMessage = "FirstName must be at least 1 character.")]
        public string FirstName {get; set;}

        [MinLength(1, ErrorMessage = "MiddleName must be at least 1 character.")]
        public string? MiddleName {get; set;}

        [Required]
        [MinLength(1, ErrorMessage = "LastName must be at least 1 character.")]
        public string LastName {get; set;}

        [Required]
        [MinLength(20, ErrorMessage = "Biography must be at least 20 characters.")]
        public string Biography {get; set;}

        [Required]
        [MinLength(2, ErrorMessage = "Nationality must be at least 2 characters.")]
        public string Nationality {get; set;}

    }

}