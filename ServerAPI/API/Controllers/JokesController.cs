using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JokesController : ControllerBase
    {
        private readonly ILogger<JokesController> _logger;
        private readonly JokesService _jokesService;

        public JokesController(ILogger<JokesController> logger, JokesService jokesService)
        {
            _jokesService = jokesService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> RandomJoke(string category)
        {
            var joke = await _jokesService.GetRandomJokeAsync(category);
            return Ok(joke);
        }

    }
}