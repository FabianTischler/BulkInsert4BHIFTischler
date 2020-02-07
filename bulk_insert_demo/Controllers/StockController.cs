using System;
using System.Threading.Tasks;
using BulkInsertDemo.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace BulkInsertDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockController : ControllerBase
    {
        private readonly IStockUpdateHandler _handler;

        public StockController(IStockUpdateHandler handler)
        {
            this._handler = handler;
        }

        [HttpPost]
        public async Task<IActionResult> AddStocks([FromBody] UpdatePackage package)
        {
            try
            {
                await this._handler.PersistStockUpdate(package);
                return Ok();
            }
            catch (Exception)
            {
                // kind of
                return BadRequest();
            }
        }
    }
}