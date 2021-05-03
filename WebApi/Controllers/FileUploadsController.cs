using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dtos;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadsController : ControllerBase
    {
        private readonly IFileUploadService fileUploadService;
        public FileUploadsController(IFileUploadService fileUploadService)
        {
            this.fileUploadService = fileUploadService;
        }
        [HttpPost]
        public async Task<IActionResult> AddFileUpload(FileUploadCreationDto fileUploadCreation)
        {
            return Ok( await  this.fileUploadService.AddFileUpload(fileUploadCreation));
        }
    }
}
