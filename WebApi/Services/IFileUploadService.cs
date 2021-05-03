using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dtos;

namespace WebApi.Services
{
  public  interface IFileUploadService
  {
      public Task<int> AddFileUpload(FileUploadCreationDto fileUploadCreation);
  }
}
