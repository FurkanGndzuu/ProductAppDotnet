namespace Photo.Api.Services
{
    public interface IStorage
    {
        Task<Dtos.File> UploadFileAsync(IFormFile file , CancellationToken cancellationToken);
        Task<bool> DeleteFileAsync(Dtos.File photo);
    }
}
