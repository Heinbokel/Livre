namespace Livre.models {

    public class BookImage: BaseDataModel {

        public int Id {get; set;}
        public string ImageUrl {get; set;}
        public string Caption {get; set;}

        // A Book Image can belong to only one book (BookId + Book designates )
        public int BookId {get; set;}
        public Book Book {get; set;}

    }

}