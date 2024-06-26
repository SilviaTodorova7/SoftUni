﻿using HouseRentingSystem.Web.ViewModels.Agent;

namespace HouseRentingSystem.Services.Data.Interfaces
{
    public interface IAgentService
    {
        Task<bool> AgentExistsByUserIdAsync(string userId);
        Task<bool> AgentExistsByPhoneNumberAsync(string phoneNumber);
        Task<bool> HasRentsByUserIdAsync(string userId);
        Task CreateAsync(string userId, BecomeAgentFormModel model);

        Task<string?> GetAgentIdByUserId(string userId);
    }
}
