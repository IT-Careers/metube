using Microsoft.AspNetCore.Http;

namespace MeTube.Service;

public interface ICloudinaryService
{
    Task<Dictionary<string, object>> UploadFile(IFormFile formFile);
}
