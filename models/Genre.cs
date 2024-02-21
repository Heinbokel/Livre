namespace Livre.models {

    public class Genre: BaseDataModel {

        public int Id {get; set;}
        public string Name {get; set;}
        public string Description {get; set;}

        // A Genre can belong to many books.
        public List<Book> Books {get; set;}

    }

}