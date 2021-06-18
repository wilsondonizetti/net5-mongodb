using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace app_mongo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MongoController : ControllerBase
    {
        private readonly MongoContext _context;
        private readonly ILogger<MongoController> _logger;

        public MongoController(ILogger<MongoController> logger, MongoContext context)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var filter = Builders<Prospects>.Filter.Empty;
            var result = await _context.Prospects.Find(filter).ToListAsync();
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prospects"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(Prospects prospects)
        {          
            await _context.Prospects.InsertOneAsync(prospects);
            return Created(prospects.Id, prospects);
        }
    }
}
