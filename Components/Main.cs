using Airways.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Airways.Components
{
    public class MainViewComponent : ViewComponent
    {
        private readonly IFlyService _flyService;
        private readonly ICityService _cityService;
        public MainViewComponent(IFlyService flyService, ICityService cityService)
        {
            _flyService = flyService;
            _cityService = cityService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var modal = await _flyService.All();

            foreach (var item in modal)
            {        
                item.CityDeparture = await _cityService.GetById(item.Departure);
                item.CityArrival = await _cityService.GetById(item.Arrival);
            }

            return View(modal);
        }
    }
}
