using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfoTrackSearch_BED.Services;

namespace InfoTrackSearch_BED.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class SearchController : Controller
    {
        private readonly ISearchService _services;

        public SearchController(ISearchService services)
        {
            _services = services;
        }
        [HttpGet]
        public async Task<ActionResult> GetGoogle(string searchValue)
        {
            if(string.IsNullOrEmpty(searchValue)) return NotFound();
            var res = await _services.SearchGoogle(searchValue);
            return Ok(res);
        }

        [HttpGet]
        public async Task<ActionResult> GetBing(string searchValue)
        {
            if (string.IsNullOrEmpty(searchValue)) return NotFound();
            var res = await _services.SearchBing(searchValue);
            return Ok(res);
        }
    }
}
