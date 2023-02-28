using AutoMapper.Configuration.Annotations;
using Newtonsoft.Json;

namespace TestCouchDB.BLL.Models
{
    public class UserModel
    {
        [JsonProperty("_id")]  
        public string Id { get; set; }
        [Ignore] 
        public string Rev { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
    }
}