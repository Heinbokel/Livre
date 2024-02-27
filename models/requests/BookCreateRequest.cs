using System.ComponentModel.DataAnnotations;

namespace Livre.models.requests {

    public class BookCreateRequest {

        [Required]
        [MinLength(1, ErrorMessage = "Title must be at least 1 character.")]
        public string Title {get; set;}

        [Required]
        [MinLength(10, ErrorMessage = "Synopsis must be at least 10 character.")]
        public string Synopsis {get; set;}

        [Required]
        public DateOnly PublicationDate {get; set;}

        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "ISBN must be exactly 10 digits long (no dashes).")]
        public string ISBN {get; set;}

        // The following lists hold ID's of the given entities, which are not required.
        // They will be used to lookup the Entities with the given ID's to be inserted into our Book before
        // finally saving the book to the database.
        public List<int> GenreIds {get; set;} = [];
        public List<int> AuthorIds {get; set;} = [];

    }

}