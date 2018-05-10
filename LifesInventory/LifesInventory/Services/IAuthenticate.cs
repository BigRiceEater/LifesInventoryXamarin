using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LifesInventory.Models;

namespace LifesInventory.Services
{
    public interface IAuthenticate
    {
        Task<bool> IsPasswordCorrect(User user);
    }
}
