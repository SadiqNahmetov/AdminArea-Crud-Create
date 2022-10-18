using EntityFrameworkProject.Data;
using EntityFrameworkProject.Models;
using EntityFrameworkProject.Services;
using EntityFrameworkProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkProject.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        private readonly LayoutService _layoutService;
        public HeaderViewComponent(AppDbContext context, LayoutService layoutService)
        {
            _context = context;
            _layoutService = layoutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int count = 0;           

            if (Request.Cookies["basket"] != null)
            {
                List<BasketVM> basket = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);
                count = basket.Count();
                //foreach (var item in basket)
                //{
                //    count += item.Count;
                //}

                count = basket.Sum(m => m.Count);
            }
            else
            {
                count = 0;
            }

            //ViewBag.count = count;


            Dictionary<string,string> datas = await _layoutService.GetDatasFromSetting();

            HeaderVM headerVM = new HeaderVM
            {
                Count = count,
                Settings = datas
            };

            return await Task.FromResult(View(headerVM));
        }

       
    }
}
