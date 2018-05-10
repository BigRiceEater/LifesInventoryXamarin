﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LifesInventory.Models;

namespace LifesInventory.Services
{
    public interface IInventoryService
    {
        Task<List<InventoryAsset>> GetInventoryListAsync(string username);
        Task AddInventoryItemAsync(InventoryAsset item);
        Task RemoveInventoryItemAsync(InventoryAsset item);
        Task UpdateInventoryItemAsync(InventoryAsset item);
    }
}
