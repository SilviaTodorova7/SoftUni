using HouseRentingSystem.Web.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentingSystem.Services.Data.Interfaces
{
    public interface IHouseService
    {
        Task<IEnumerable<IndexViewModel>> LastThreeHousesAsync();
    }
}
