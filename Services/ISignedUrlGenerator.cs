namespace S3POC.API.Services
{
    public interface ISignedUrlGenerator
    {
        //Method to access file url from a private S3 bucket
        string GetPreSignedUrl(string bucketName, string objectKey);
    }
}
