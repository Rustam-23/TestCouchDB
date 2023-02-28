namespace TestCouchDB.DAL.Entities
{
    public class RecordEntity : BaseEntity
    {
        public string Title { get; set; }
        public string State { get; set; }
        public string AssignId { get; set; }
    }
}