using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace LifesInventory.Models
{
    public abstract class Asset
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public string Owner { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        // TODO: Category should be settable by user. 
        public string Category { get; set; }
    }
}
