﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.WebApplication.Services.Abstract;

namespace PortfolioWithBlog.Areas.User.Controllers
{
    [Authorize(Roles = "SuperAdmin,Member")]
    [Area("User")]
    public class DashboardController : Controller
    {
        private readonly INewsFeedService _newsFeedService;

        public DashboardController(INewsFeedService newsFeedService)
        {
            _newsFeedService = newsFeedService;
        }

        public async Task<IActionResult> Index()
        {      
            var lastNews = await _newsFeedService.GetLastFiveNewsListForUserAsync();
            return View(lastNews);
        }
    }
}
