namespace Livre.models {

    public class Book: BaseDataModel {

        public int Id {get; set;}
        public DateOnly PublicationDate {get; set;}
        public string ISBN {get; set;}
        public List<Genre> Genres {get; set;}
        public List<Author> Authors {get; set;}
        public List<BookImage> BookImages {get; set;}

    }

}