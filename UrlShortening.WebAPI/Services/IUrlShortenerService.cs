using UrlShortening.WebAPI.Models;

namespace UrlShortening.WebAPI.Services
{
    public interface IUrlShortenerService
    {
        public ResponseDto Encode(string url);

        public ResponseDto Decode(string encodedCode);

        public ResponseDto DecodeUrl(string encodedUrl);
    }
}
