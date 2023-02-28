using AutoMapper.Configuration.Annotations;
using Newtonsoft.Json;

namespace TestCouchDB.BLL.Models
{
    public class RecordModel
    {
        [JsonProperty("_id")]  
        public string Id { get; set; }
        [Ignore] 
        public string Rev { get; set; }
        public string Title { get; set; }
        public string State { get; set; }
        public string AssignId { get; set; }
    }
}