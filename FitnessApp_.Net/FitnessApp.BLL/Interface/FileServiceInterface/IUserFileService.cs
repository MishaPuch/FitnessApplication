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
    public interface IUserFileService
    {
        public Task<List<BlobDto>> ListAsync();
        public Task<BlobResponseDto> UploadFile(IFormFile blob, User user);
        public Task<BlobResponseDto> DeleteFileAsync(User user);
        public string MakeAvatarFileName(IFormFile blob, User user);
       
    }
}
