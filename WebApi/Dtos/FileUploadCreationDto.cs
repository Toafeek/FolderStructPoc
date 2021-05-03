using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.StaticFiles;
using WebApi.Models;

namespace WebApi.Dtos
{
    public class FileUploadCreationDto
    {
        public int FolderId { get; set; }

        public string Name { get; set; }

        public string Key { get; set; }

        public FolderType FolderType { get; set; }
    }
}
