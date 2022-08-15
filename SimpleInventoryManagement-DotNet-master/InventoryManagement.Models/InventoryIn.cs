using System;

namespace InventoryManagement.Models
{
    public class InventoryIn
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public DateTime ItemInDate { get; set; }
        public int Qty { get; set; }
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
