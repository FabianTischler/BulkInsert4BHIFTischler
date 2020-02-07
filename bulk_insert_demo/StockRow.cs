using System;

namespace BulkInsertDemo
{
    public class StockRow
    {
        public DateTime Timestamp { get; set; }
        public int StoreNo { get; set; }
        public int ProductCode { get; set; }
        public int Stock { get; set; }
    }
}