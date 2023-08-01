namespace Photo.Api.Services
{
    public class StorageService : IStorage
    {
        public async Task<bool> DeleteFileAsync(Dtos.File photo)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", photo.Uri);

            if (File.Exists(path))
            {
                File.Delete(path);
                return true;
            }
            return false;
        }

        public async Task<Dtos.File> UploadFileAsync(IFormFile photo, CancellationToken cancellationToken)
        {
            if (photo != null && photo.Length > 0)
            {
                var randomFileName = Guid.NewGuid().ToString() + Path.GetExtension(photo.FileName);

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/photos", randomFileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await photo.CopyToAsync(stream, cancellationToken);
                }
                var returnPath = "photos/" + randomFileName;

                return new (){ Uri = returnPath };
            }
            else
            {
                throw new ArgumentNullException(nameof(photo));
            }
        }
    }
}
