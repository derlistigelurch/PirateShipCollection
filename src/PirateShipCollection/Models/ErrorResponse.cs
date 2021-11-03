using System.Runtime.Serialization;

namespace PirateShipCollection.Models
{
    [DataContract]
    public class ErrorResponse
    {
        [DataMember(Name = "type")]
        public string Type { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }

        [DataMember(Name = "stacktrace")]
        public string StackTrace { get; set; }
    }
}