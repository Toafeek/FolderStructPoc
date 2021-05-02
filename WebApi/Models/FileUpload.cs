using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
	public class FileUpload
	{
		public int Id {get; set; }

		public string Key { get; set; }

		public string Name { get; set; }

		public int FolderId { get; set; }

		public Folder Folder { get; set; }

		public  FolderType FolderType { get; set; }
	}
}
