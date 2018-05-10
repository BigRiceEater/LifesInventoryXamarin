using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace LifesInventory.Models
{
    public class Category
    {
        [PrimaryKey]
        public string Name { get; set; }
    }
}
