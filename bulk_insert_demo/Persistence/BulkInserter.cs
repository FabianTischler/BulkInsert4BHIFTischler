using System.Linq;
using System.Threading.Tasks;
using EFCore.BulkExtensions;

namespace BulkInsertDemo.Persistence
{
    public sealed class BulkInserter : StockUpdateHandlerBase
    {
        // this is a little rough but should suffice for the example
        private readonly BulkContext _context;

        public BulkInserter(BulkContext context)
        {
            this._context = context;
        }

        protected override async Task Persist(UpdatePackage package)
        {
            await using var transaction = await this._context.Database.BeginTransactionAsync();

            // can't be enumerable because the lib needs to know the total count for batching
            var rows = GetRows(package).ToList();
            //await this._context.BulkInsertAsync(rows);

            await this._context.BulkInsertOrUpdateAsync(rows);

            await this._context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
    }
}