using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestCouchDB.BLL.Interfaces;
using TestCouchDB.BLL.Models;

namespace TestCouchDB.Controllers
{
    [ApiController]
    [Route("api/records")]
    public class RecordController : ControllerBase
    {
        private readonly IRecordService _recordService;


        public RecordController(IRecordService recordService)
        {
            _recordService = recordService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var records = _recordService.GetAll();
            return Ok(records);
        }

        [HttpPost]
        public async Task<IActionResult> Create(RecordModel recordModel)
        {
            var id = await _recordService.Create(recordModel);
            return Ok(id);
        }

        [HttpPut]
        public async Task<IActionResult> Update(RecordModel recordModel)
        {
            var checker = await _recordService.Update(recordModel);
            return Ok(checker);
        }
    }
}