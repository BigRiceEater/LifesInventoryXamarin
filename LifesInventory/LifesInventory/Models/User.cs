using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace LifesInventory.Models
{
    public class User
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
