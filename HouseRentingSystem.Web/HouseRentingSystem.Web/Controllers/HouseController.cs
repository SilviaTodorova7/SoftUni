using HouseRentingSystem.Services.Data.Interfaces;
using HouseRentingSystem.Web.Infrastructure.Extensions;
using HouseRentingSystem.Web.ViewModels.House;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static HouseRentingSystem.Common.NotificationMessagesConstants;

namespace HouseRentingSystem.Web.Controllers
{
    [Authorize]
    public class HouseController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IAgentService agentService;
        private readonly IHouseService houseService;

        public HouseController(ICategoryService categoryService, IAgentService agentService, IHouseService houseService)
        {
             this.categoryService = categoryService;
            this.agentService = agentService;
            this.houseService = houseService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> All()
        {
            return this.Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            bool isAgent = 
                await this.agentService.AgentExistsByUserIdAsync(this.User.GetId()!);
            if (!isAgent)
            {
                this.TempData[ErrorMessage] = "You must be an agent in order to add new houses!";

                return this.RedirectToAction("Become", "Agent");
            }


            HouseFormModel model = new HouseFormModel()
            {
                Categories = await this.categoryService.AllCategoriesAsync()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(HouseFormModel model)
        {
            bool isAgent =
                await this.agentService.AgentExistsByUserIdAsync(this.User.GetId()!);
            if (!isAgent)
            {
                this.TempData[ErrorMessage] = "You must be an agent in order to add new houses!";

                return this.RedirectToAction("Become", "Agent");
            }

            bool categoryExists = await this.categoryService.ExistsByIdAsync(model.CategoryId);

            if (!categoryExists)
            {
                this.ModelState.AddModelError(nameof(model.CategoryId), "Selected category does not exists!");
            }

            if (!this.ModelState.IsValid)
            {
                model.Categories = await this.categoryService.AllCategoriesAsync();

                return this.View(model);
            }

            try
            {
                string? agentId = await this.agentService.GetAgentIdByUserId(this.User.GetId()!);
                await this.houseService.CreateAsync(model, agentId!);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "Unexpected error occured while trying to add new house. Please try again later or contact administrator.");
                model.Categories = await this.categoryService.AllCategoriesAsync();

                return this.View(model);
            }

            return this.RedirectToAction("All", "House");
        }
    }
}
