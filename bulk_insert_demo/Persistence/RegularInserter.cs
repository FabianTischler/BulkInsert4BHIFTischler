using System.Threading.Tasks;
using System.Linq;

namespace BulkInsertDemo.Persistence
{
    public sealed class RegularInserter : StockUpdateHandlerBase
    {
        // this is a little rough but should suffice for the example
        private readonly BulkContext _context;

        public RegularInserter(BulkContext context)
        {
            this._context = context;
        }

        protected override async Task Persist(UpdatePackage package)
        {
            await using var transaction = await this._context.Database.BeginTransactionAsync();
            foreach (var stockRow in GetRows(package))
            {
                int cnt = this._context.Stocks.Select(i => i.StoreNo).Where(i => i == stockRow.StoreNo).Count();
                if (cnt >= 1)
                {
                    var entity = await this._context.Stocks.FindAsync(stockRow.StoreNo);
                    entity.ProductCode = stockRow.ProductCode;
                    entity.Stock = stockRow.Stock;
                    entity.Timestamp = stockRow.Timestamp;
                }
                else
                {
                    await this._context.Stocks.AddAsync(stockRow);
                }
            }
            await this._context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
    }
}