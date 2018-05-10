using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace LifesInventory.Models
{
    public class InventoryAsset : Asset
    {
        public DateTime PurchaseDate { get; set; }
    }
}
