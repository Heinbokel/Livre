namespace Livre.models {

    public class Book: BaseDataModel {

        public int Id {get; set;}
        public DateOnly PublicationDate {get; set;}
        public string ISBN {get; set;}

        // A Book can have many Genres
        public List<Genre> Genres {get; set;}

        // A Book can have many Authors
        public List<Author> Authors {get; set;}

        // A Book can have many Book Images
        public List<BookImage> BookImages {get; set;}

    }

}