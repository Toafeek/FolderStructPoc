using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Dtos
{
	public class FileUploadListItem
	{
		public int Id { get; set; }

		public string Key { get; set; }

		public string Name { get; set; }

		public int FolderId { get; set; }


		public FolderType FolderType { get; set; }
	}
}
