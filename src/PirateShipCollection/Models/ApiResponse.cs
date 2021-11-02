using System;
using System.Runtime.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace PirateShipCollection.Models
{
    [DataContract]
    public class ApiResponse
    {
        [DataMember(Name = "code")]
        public int Code { get; set; }
        
        [DataMember(Name = "type")]
        public string Type { get; set; }
        
        [DataMember(Name = "message")]
        public string Message { get; set; }
    }
}