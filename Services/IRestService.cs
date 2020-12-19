using MobileGuide.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileGuide.Services
{
    public interface IRestService
    {
        Task<List<Restaurant>> FetchFoodMenu();
    }
}
