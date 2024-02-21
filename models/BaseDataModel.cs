using System.Text.Json.Serialization;

namespace Livre.models {

    public abstract class BaseDataModel {

        [JsonIgnore]
        public DateTime CreatedDateTime {get; set;}

        [JsonIgnore]
        public DateTime? UpdatedDateTime {get; set;}

        [JsonIgnore]
        public int CreatedByUserId {get; set;}

        [JsonIgnore]
        public int? UpdatedByUserId {get; set;}

    }

}