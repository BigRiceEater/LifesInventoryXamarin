using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LifesInventory.Models;

namespace LifesInventory.Services
{
    public interface IWishListService
    {
        Task<List<WishListAsset>> GetWishListAsync(string username);
        Task AddWishListItemAsync(WishListAsset item);
        Task RemoveWishListItemAsync(WishListAsset item);
        Task UpdateWishListItemAsync(WishListAsset item);
    }
}
