using Azure.Storage.Blobs;
using FitnessApp.DAL.Models;
using FitnessApp.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BLL.Interface.FileServiceInterface
{
    public interface ITreningFileService
    {
        public Task<List<BlobDto>> ListAsync();
        public Task<BlobResponseDto> UploadFile(IFormFile blob, Exercise exercise);
        public Task<BlobDto> DownloadFileAsync(string blobFileName);
        public Task<BlobResponseDto> DeleteFileAsync(Exercise exercise);
        public string MakeExerciseFileName(IFormFile blob, Exercise exercise);
        
    }
}
