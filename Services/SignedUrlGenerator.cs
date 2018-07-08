using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.Extensions.Configuration;
using System;

namespace S3POC.API.Services
{
    public class SignedUrlGenerator : ISignedUrlGenerator
    {
        private readonly string _accessKey;
        private readonly string _secretKey;
        private readonly string _serviceUrl;

        public SignedUrlGenerator(IConfiguration configuration)
        {
            _accessKey = configuration["AccessKey"];
            _secretKey = configuration["SecretKey"];
            _serviceUrl = configuration["ServiceUrl"];
        }

        //Method to access file url from a private S3 bucket
        public string GetPreSignedUrl(string bucketName, string objectKey)
        {
            var config = new AmazonS3Config { ServiceURL = _serviceUrl };

            var s3Client = new AmazonS3Client(_accessKey, _secretKey, config);

            var preSignedUrlRequest = new GetPreSignedUrlRequest { BucketName = bucketName, Key = objectKey, Expires = DateTime.UtcNow.AddMinutes(15) };

            return s3Client.GetPreSignedURL(preSignedUrlRequest);
        }
    }
}
