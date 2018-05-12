using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LifesInventory.Models;
using SQLite;

namespace LifesInventory.Services
{
    public class SqlInventoryService : IInventoryService
    {
        public SqlInventoryService()
        {
            using (var conn = new SQLiteConnection(App.DbLocation))
            {
                conn.CreateTable<InventoryAsset>();
            }
        }

        public async Task<List<InventoryAsset>> GetInventoryListAsync(string username)
        {
            var db = new SQLiteAsyncConnection(App.DbLocation);
            //return await db.Table<InventoryAsset>().Where(
            //    _ => _.Owner.ToLower() == username.ToLower()
            //).ToListAsync();
            return await db.Table<InventoryAsset>().ToListAsync();
        }

        public async Task<int> AddInventoryItemAsync(InventoryAsset item)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DbLocation))
            {
                var rows = conn.Insert(item);
                return rows;
            }
        }

        public async Task<int> RemoveInventoryItemAsync(InventoryAsset item)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DbLocation))
            {
                var rows = conn.Delete(item);
                return rows;
            }
        }

        public Task UpdateInventoryItemAsync(InventoryAsset item)
        {
            throw new NotImplementedException();
        }
    }
}
