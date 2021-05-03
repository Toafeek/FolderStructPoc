using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Dtos
{
	public class FolderItems
	{
		public List<FolderListItemDto> Children { get; set; }
		public List<FileUploadListItem> FileUploads { get; set; }
	}
}
