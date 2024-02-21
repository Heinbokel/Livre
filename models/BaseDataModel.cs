namespace Livre.models {

    public abstract class BaseDataModel {

        public DateTime CreatedDateTime {get; set;}
        public DateTime? UpdatedDateTime {get; set;}
        public int CreatedByUserId {get; set;}
        public int UpdatedByUserId {get; set;}

    }

}