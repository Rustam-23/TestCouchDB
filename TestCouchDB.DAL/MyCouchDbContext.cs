using CouchDB.Driver;
using CouchDB.Driver.Options;
using TestCouchDB.DAL.Entities;

namespace TestCouchDB.DAL
{
    public class MyCouchDbContext : CouchContext
    {
        public MyCouchDbContext(CouchOptions<MyCouchDbContext> options)
            : base(options) { }
        
        public CouchDatabase<UserEntity> Users { get; set; }
        public CouchDatabase<RecordEntity> Records { get; set; }
        
        protected override void OnDatabaseCreating(CouchDatabaseBuilder databaseBuilder)
        {
            databaseBuilder.Document<UserEntity>().ToDatabase("my-couch-db");
            databaseBuilder.Document<RecordEntity>().ToDatabase("my-couch-db");
        }
    }
}