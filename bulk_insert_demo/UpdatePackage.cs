using System;
using System.Collections.Generic;

namespace BulkInsertDemo
{
    public sealed class UpdatePackage
    {
        public int StoreNo { get; set; }
        public DateTime Timestamp { get; set; }
        public IReadOnlyCollection<ProductStock> Stocks { get; set; }
    }
}