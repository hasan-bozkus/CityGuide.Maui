using CityGuide.WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityGuide.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialEventsController : ControllerBase
    {
        private readonly AppDatabase _appDatabase;

        public SpecialEventsController(AppDatabase appDatabase)
        {
            _appDatabase = appDatabase;
        }

        [HttpGet("GetSpecialEvents")]
        public async Task<IActionResult> GetSpecialEvents()
        {
            var events = await _appDatabase.GetSpecialEventsAsync();
            return Ok(events);
        }
    }
}
