using Azure.Storage;
using Azure.Storage.Blobs;
using FitnessApp.DAL.DiRepositories;
using FitnessApp.DAL.Models;
using FitnessApp.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FitnessApp.BLL.Services
{
    public class UserFileService
    {
        private readonly string _storageAccount = "fitnessapp";
        private readonly string _key = "V4tLrHmmwyI/npR8wIzqs6g23spab0EiKy0QoHrfbe8mcjo05VJrskggVMrPS1EkKAQYbMpY08Xv+AStZEaLXg==";
        private readonly BlobContainerClient _fileAvatarsConteiner;
        private readonly UserRepository _userRepository;

        public UserFileService()
        {
            var credential = new StorageSharedKeyCredential(_storageAccount, _key);
            var blobUri = $"https://{_storageAccount}.blob.core.windows.net";
            var blobServiceClient = new BlobServiceClient(new Uri(blobUri), credential);
            _fileAvatarsConteiner = blobServiceClient.GetBlobContainerClient("avatars");
        }
        public UserFileService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<BlobDto>> ListAsync()
        {
            List<BlobDto> files = new List<BlobDto>();

            await foreach (var file in _fileAvatarsConteiner.GetBlobsAsync())
            {
                string uri = _fileAvatarsConteiner.Uri.ToString();
                var name = file.Name;
                var fullUri = $"{uri}/{name}";

                files.Add(new BlobDto
                {
                    Name = name,
                    Uri = fullUri,
                    ContentType = file.Properties.ContentType
                });
            }

            return files;
        }
        public async Task<BlobResponseDto> UploadFile(IFormFile blob , User user)
        {
            await DeleteFileAsync(user);
            BlobResponseDto response = new BlobResponseDto();
            BlobClient client = _fileAvatarsConteiner.GetBlobClient(user.UserEmail+Path.GetExtension(blob.FileName));
            
            await using (Stream? data = blob.OpenReadStream())
            {
                await client.UploadAsync(data);
            }

            response.Status = $"File {blob.FileName} Uploaded Seccessfuly";
            response.Error = false;

            response.Blob.Name = user.UserEmail;
            response.Blob.Uri = client.Uri.AbsoluteUri;

            user.Avatar = user.UserEmail + Path.GetExtension(blob.FileName);
            await _userRepository.UpdateUserAsync(user);

            return response;

        }

        public async Task<BlobResponseDto> DeleteFileAsync(User user)
        {
            BlobClient file = _fileAvatarsConteiner.GetBlobClient(user.Avatar);
            if (await file.ExistsAsync())
            {
                await file.DeleteAsync();
            }

            return new BlobResponseDto { Error = false, Status = $"File {file.Name} - was seccessfully deleted" };
        }
    }
}
