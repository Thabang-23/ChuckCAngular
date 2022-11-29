using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly JokesService _jokesService;
        private readonly ILogger<CategoryController> _logger;
        public CategoryController(ILogger<CategoryController> logger, JokesService jokesService)
        {
            _logger = logger;
            _jokesService = jokesService;
        }

        [HttpGet]
        public async Task<IActionResult> Categories()
        {
            var categories = await _jokesService.GetCategoriesResponseAsync();

            // JObject json = JObject.Parse(categories);
            
            return Ok(categories);
        }
    }
}