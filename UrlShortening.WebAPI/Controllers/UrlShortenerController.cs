using Microsoft.AspNetCore.Mvc;
using UrlShortening.WebAPI.Services;

namespace UrlShortening.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlShortenerController : ControllerBase
    {
        private readonly IUrlShortenerService _service;

        public UrlShortenerController(IUrlShortenerService service)
        {
            _service = service;
        }

        [HttpPost("Generate")]
        public ActionResult Encode(string url)
        {
            var encodedUrl = _service.Encode(url);

            return Ok(encodedUrl);
        }

        [HttpPost("Dispatch")]
        public ActionResult Decode(string code)
        {
            var decodedUrl = _service.Decode(code);

            return Ok(decodedUrl);
        }

        [HttpPost("DispatchUrl")]
        public ActionResult DecodeUrl(string url)
        {
            var decodedUrl = _service.DecodeUrl(url);

            return Ok(decodedUrl);
        }
    }
}
