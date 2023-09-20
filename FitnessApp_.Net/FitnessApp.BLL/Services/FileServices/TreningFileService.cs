using Azure.Storage;
using Azure.Storage.Blobs;
using FitnessApp.DAL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BLL.Services
{
    public class TreningFileService
    {
        private readonly string _storageAccount = "fitnessapp";
        private readonly string _key = "V4tLrHmmwyI/npR8wIzqs6g23spab0EiKy0QoHrfbe8mcjo05VJrskggVMrPS1EkKAQYbMpY08Xv+AStZEaLXg==";
        private readonly BlobContainerClient _fileTreningsConteiner;

        public TreningFileService()
        {
            var credential = new StorageSharedKeyCredential(_storageAccount, _key);
            var blobUri = $"https://{_storageAccount}.blob.core.windows.net";
            var blobServiceClient = new BlobServiceClient(new Uri(blobUri), credential);
            _fileTreningsConteiner = blobServiceClient.GetBlobContainerClient("exercisevideos");
        }

        public async Task<List<BlobDto>> ListAsync()
        {
            List<BlobDto> files = new List<BlobDto>();

            await foreach (var file in _fileTreningsConteiner.GetBlobsAsync())
            {
                string uri = _fileTreningsConteiner.Uri.ToString();
                var name = file.Name;
                var fullUri = $"{uri}/{name}";

                files.Add(new BlobDto
                {
                    Name = name,
                    Uri = uri,
                    ContentType = file.Properties.ContentType
                });
            }

            return files;
        }
        public async Task<BlobResponseDto> UploadFile(IFormFile blob)
        {
            BlobResponseDto response = new BlobResponseDto();
            BlobClient client = _fileTreningsConteiner.GetBlobClient(blob.FileName);

            await using (Stream? data = blob.OpenReadStream())
            {
                await client.UploadAsync(data);
            }

            response.Status = $"File {blob.FileName} Uploaded Seccessfuly";
            response.Error = false;
            response.Blob.Uri = client.Uri.AbsoluteUri;
            response.Blob.Name = client.Name;

            return response;

        }

        public async Task<BlobDto> DownloadFileAsync(string blobFileName)
        {
            BlobClient file = _fileTreningsConteiner.GetBlobClient(blobFileName);

            if (await file.ExistsAsync())
            {
                var data = await file.OpenReadAsync();
                Stream blobContent = data;

                var content = await file.DownloadContentAsync();
                string name = file.Name;
                string contentType = content.Value.Details.ContentType;

                return new BlobDto { ContentType = contentType, Name = name, Content = blobContent };
            }

            return null;
        }

        public async Task<BlobResponseDto> DeleteFileAsync(string blobFileName)
        {
            BlobClient file = _fileTreningsConteiner.GetBlobClient(blobFileName);
            if (await file.ExistsAsync())
            {
                await file.DeleteAsync();
            }

            return new BlobResponseDto { Error = false, Status = $"File {file.Name} - was seccessfully deleted" };
        }
    }
}
