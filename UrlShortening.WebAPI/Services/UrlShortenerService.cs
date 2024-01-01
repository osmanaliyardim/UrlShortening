using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;
using UrlShortening.WebAPI.Context;
using UrlShortening.WebAPI.Models;

namespace UrlShortening.WebAPI.Services
{
    public class UrlShortenerService : IUrlShortenerService
    {
        private readonly ApplicationDbContext _context;
        private static readonly string baseUrl = "http://blabla.com/";

        public UrlShortenerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public ResponseDto Encode(string url)
        {
            if (url.IsNullOrEmpty())
            {
                return new ResponseDto { IsSuccess = false, Message = "URL cannot be empty/null!" };
            }

            HashAlgorithm md5HashingAlgo = MD5.Create();

            byte[] hashBytes = md5HashingAlgo.ComputeHash(Encoding.UTF8.GetBytes(url));

            string encodedCode = Convert.ToBase64String(hashBytes).Substring(0, 6);

            HashedUrl encodedResult = new()
            {
                Id = new Guid(),
                DecodedUrl = url,
                EncodedUrl = baseUrl + encodedCode,
                Code = encodedCode
            };

            _context.HashedUrls.Add(encodedResult);
            _context.SaveChanges();

            return new ResponseDto { Message = $"Url has successfully shortened as {encodedResult.EncodedUrl} with the code {encodedResult.Code}", Result = encodedResult };
        }

        public ResponseDto Decode(string encodedCode)
        {
            if (encodedCode.IsNullOrEmpty())
            {
                return new ResponseDto { IsSuccess = false, Message = "Code cannot be empty/null!" };
            }
            else if (!_context.HashedUrls.Any(u => u.Code == encodedCode))
            {
                return new ResponseDto { IsSuccess = false, Message = "Not Found: This Code has NOT shortened before. Try another one!" };
            }

            var decodedResult = _context.HashedUrls.FirstOrDefault(x => x.EncodedUrl == baseUrl + encodedCode);

            return new ResponseDto { Message = $"Code has successfully decoded as {decodedResult?.DecodedUrl}", Result = decodedResult };
        }

        public ResponseDto DecodeUrl(string encodedUrl)
        {
            if (encodedUrl.IsNullOrEmpty())
            {
                return new ResponseDto { IsSuccess = false, Message = "URL cannot be empty/null!" };
            }
            else if (!_context.HashedUrls.Any(u => u.EncodedUrl == encodedUrl))
            {
                return new ResponseDto { IsSuccess = false, Message = "Not Found: This URL has NOT shortened before. Try another one!" };
            }

            var decodedResult = _context.HashedUrls.FirstOrDefault(x => x.EncodedUrl == encodedUrl);

            return new ResponseDto { Message = $"Url has successfully decoded as {decodedResult?.DecodedUrl}", Result = decodedResult };
        }
    }
}
