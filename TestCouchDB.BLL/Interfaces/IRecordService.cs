using System.Collections.Generic;
using System.Threading.Tasks;
using TestCouchDB.BLL.Models;

namespace TestCouchDB.BLL.Interfaces
{
    public interface IRecordService
    {
        public List<RecordModel> GetAll();
        public Task<bool> Create(RecordModel recordModel);
        public Task<bool> Update(RecordModel recordModel);
    }
}