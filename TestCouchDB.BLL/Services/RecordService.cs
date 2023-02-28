using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TestCouchDB.BLL.Interfaces;
using TestCouchDB.BLL.Models;
using TestCouchDB.DAL;
using TestCouchDB.DAL.Entities;

namespace TestCouchDB.BLL.Services
{
    public class RecordService : IRecordService
    {
        private readonly MyCouchDbContext _context;
        private readonly IMapper _mapper;

        public RecordService(MyCouchDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public List<RecordModel> GetAll()
        {
            var users = _context.Records.ToList();
            return _mapper.Map<List<RecordModel>>(users);
        }
        
        public async Task<bool> Create(RecordModel recordModel)
        {
            var record = _mapper.Map<RecordEntity>(new RecordModel
            { 
                Title = recordModel.Title,
                State = recordModel.State,
                AssignId = recordModel.AssignId 
            });

            await _context.Records.AddAsync(record);

            return true;
        }

        public async Task<bool> Update(RecordModel recordModel)
        {
            var recordForUpdate = await _context.Records.FindAsync(recordModel.Id);

            if (recordForUpdate != null)
            {
                recordForUpdate.Rev = recordModel.Rev;
                recordForUpdate.Title = recordModel.Title;
                recordForUpdate.State = recordModel.State;
                recordForUpdate.AssignId = recordModel.AssignId;
            }

            await _context.Records.AddOrUpdateAsync(recordForUpdate);
            
            return true;
        }
    }
}