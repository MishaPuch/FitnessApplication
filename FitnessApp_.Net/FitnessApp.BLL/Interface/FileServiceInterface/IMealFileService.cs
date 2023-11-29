using Azure.Storage.Blobs;
using FitnessApp.DAL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BLL.Interface.FileServiceInterface
{
    public interface IMealFileService
    {
        public Task<List<BlobDto>> ListOfMealBlobsAsync();
        public Task<BlobResponseDto> UploadFile(IFormFile blob);
        public Task<BlobDto> DownloadFileAsync(string blobFileName);
        public Task<BlobResponseDto> DeleteFileAsync(string blobFileName);
    }
}
