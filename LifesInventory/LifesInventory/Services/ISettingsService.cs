using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LifesInventory.Models;

namespace LifesInventory.Services
{
    public interface ISettingsService
    {
        Task<AppSettings> GetSettingsAsync();
        Task AddSettingsAsync(AppSettings settings);
        Task RemoveSettingsAsync(AppSettings settings);
        Task UpdateSettingsAsync(AppSettings settings);
    }
}
