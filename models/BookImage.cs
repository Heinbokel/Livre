namespace Livre.models {

    public class BookImage: BaseDataModel {

        public int Id {get; set;}
        public string ImageUrl {get; set;}
        public string Caption {get; set;}

        // Foreign Keys for One to Many 
        public int BookId {get; set;}
        public Book Book {get; set;}

    }

}