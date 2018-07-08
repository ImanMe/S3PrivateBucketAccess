using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using S3POC.API.Services;

namespace S3POC.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ISignedUrlGenerator _signedUrlGenerator;
        private readonly string _bucketName;
        public ValuesController(ISignedUrlGenerator signedUrlGenerator, IConfiguration configuration)
        {
            _signedUrlGenerator = signedUrlGenerator;
            _bucketName = configuration["CategoryBucket"];
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            //File name to be retrieved from the database
            //In case of folder structure, folder name should to be prepend to file name
            const string objectKey = "bizli.jpg";
            var signedUrl = _signedUrlGenerator.GetPreSignedUrl(_bucketName, objectKey);
            return Ok(signedUrl);
        }
    }
}
