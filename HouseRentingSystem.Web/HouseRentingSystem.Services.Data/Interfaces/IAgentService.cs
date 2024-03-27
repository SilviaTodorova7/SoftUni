using HouseRentingSystem.Web.ViewModels.Agent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Services.Data.Interfaces
{
    public interface IAgentService
    {
        Task<bool> AgentExistsByUserIdAsync(string userId);
        Task<bool> AgentExistsByPhoneNumberAsync(string phoneNumber);
        Task<bool> HasRentsByUserIdAsync(string userId);
        Task Create(string userId, BecomeAgentFormModel model);
    }
}
