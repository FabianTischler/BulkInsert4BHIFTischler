using System;

namespace BulkInsertDemo
{
    public class StockInfo
    {
        public int StoreNo { get; set; }
        public int ProductCode { get; set; }
        public DateTime Timestamp { get; set; }
        public int StockCount { get; set; }
    }
}