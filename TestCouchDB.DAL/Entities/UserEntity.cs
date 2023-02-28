namespace TestCouchDB.DAL.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
    }
}