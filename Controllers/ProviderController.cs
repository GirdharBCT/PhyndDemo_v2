﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhyndDemo_v2.Data;
using PhyndDemo_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhyndDemo_v2.Controllers
{
    [Route("providers")]
    [ApiController]
    public class ProviderController : Controller
    {
        private readonly phynd2Context context;

        public ProviderController(phynd2Context context)
        {
            this.context = context;

        }

        [HttpGet] //"providers"
        public async Task<ActionResult<List<Provider>>> Get()
        {
            var providers = await context.Providers.AsNoTracking().ToListAsync();
            //var genresDTOs = mapper.Map<List<GenreDTO>>(genres);
            return providers;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}