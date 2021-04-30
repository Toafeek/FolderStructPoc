using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Dtos
{
	public class FolderListItemDto
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public int ParentId { get; set; }

		public int UserId { get; set; }

		public FolderType FolderType { get; set; }
	}
}
