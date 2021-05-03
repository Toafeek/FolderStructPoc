using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Dtos;
using WebApi.Services;

namespace WebApi.Models
{
    public class FileUploadService : IFileUploadService
    {
        private readonly AppDbContext dbContext;
        public FileUploadService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> AddFileUpload(FileUploadCreationDto fileUploadCreation)
        {
          var fileUpload = new FileUpload
          {
              FolderType = fileUploadCreation.FolderType,
              FolderId = fileUploadCreation.FolderId,
              Key = fileUploadCreation.Key,
              Name = fileUploadCreation.Name
          };

          await this.dbContext.FileUploads.AddAsync(fileUpload);
           await this.dbContext.SaveChangesAsync();
           return fileUpload.Id;

        }
    }
}
