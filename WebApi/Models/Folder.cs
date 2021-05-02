using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
	public class Folder
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public int ParentId { get; set; }

		public int UserId { get; set; }

		public virtual Folder Parent { get; set; }

		public FolderType FolderType { get; set; }

		public virtual ICollection<Folder> Children { get; set; }
		public virtual ICollection<FileUpload> FileUploads { get; set; }
	}

	public enum FolderType
	{
		Images,
		Fonts
	}
}
