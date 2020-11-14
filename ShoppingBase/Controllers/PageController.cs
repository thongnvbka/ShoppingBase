﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoppingBase.Application.Interfaces;

namespace ShoppingBase.Controllers
{
    public class PageController : Controller
    {
        private IPageService _pageService;

        public PageController(IPageService pageService)
        {
            _pageService = pageService;
        }

        [Route("page/{alias}.html", Name = "Page")]
        public IActionResult Index(string alias)
        {
            var page = _pageService.GetByAlias(alias);
            return View(page);
        }
    }
}