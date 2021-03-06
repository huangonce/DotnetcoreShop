﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyShop.Data;
using MyShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private readonly MyDbContext _context;

        public CategoriesController(MyDbContext context)
        {
            _context = context;
        }


        [HttpGet("childs/{id?}")]
        public async Task<ActionResult> GetAll(int? id)
        {
            if(id.HasValue)
            {
                return Json(await _context.Categories.Where(c => c.ParentId == id).ToListAsync());
            }
            else
            {
                return Json(await _context.Categories.Where(c => c.ParentId == null).ToListAsync());
            }
        }
    }
}
