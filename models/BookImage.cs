using System.Text.Json.Serialization;

namespace Livre.models {

    public class BookImage: BaseDataModel {

        public int Id {get; set;}
        public string ImageUrl {get; set;}
        public string Caption {get; set;}

        // A Book Image can belong to only one book (BookId + Book designates a foreign key to the Book entity)
        public int BookId {get; set;}
        
        [JsonIgnore]
        public Book Book {get; set;}

    }

}