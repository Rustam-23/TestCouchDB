using System;
using CouchDB.Driver.Types;
using Newtonsoft.Json;

namespace TestCouchDB.DAL.Entities
{
    public class BaseEntity : CouchDocument
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }
}