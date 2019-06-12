using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using XmlJsonSerialization.Infrastructure;
using XmlJsonSerialization.Models;

namespace XmlJsonSerialization.Controllers
{
    //[Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CIController : Controller
    {
        private readonly ICinematicItemRepository _cinematicItemRepository;

        public CIController(ICinematicItemRepository cinematicItemRepository)
        {
            _cinematicItemRepository = cinematicItemRepository;
        }

        // GET: api/ci
        [HttpGet]
        public JsonResult Get()
        {
            return Json(_cinematicItemRepository.CinematicItems());
        }

        // GET: api/ci/search?fragment=ir
        [HttpGet("Search")]
        public IActionResult Search(string fragment)
        {
            var result = _cinematicItemRepository.GetByPartialName(fragment);
            if (!result.Any())
            {
                return NotFound(fragment);
            }
            return Ok(result);
        }

        // GET api/ci/IM1
        [HttpGet("{shortName}")]
        public CinematicItem Get(string shortName)
        {
            return _cinematicItemRepository.GetByShortName(shortName);
        }

        // GET api/ci/about
        [HttpGet("About")]
        public ContentResult About()
        {
            return Content("Movies from the Marvel Cinematic Universe");
        }

        // GET api/ci/version
        [HttpGet("version")]
        public string Version()
        {
            return "Version 1.0.0";
        }
    }
}
