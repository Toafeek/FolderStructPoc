using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dtos;
using WebApi.Models;

namespace WebApi.Services
{
	public interface IFolderService
	{
		public Task<int> CreateFolder(FolderCreationDto folderCreationDto);

		public Task<FolderItems> GetSubfolders(int parentId);

		public Task MoveFolder(int ToId, int id);

		public Task RemoveFolder(int id);

		public Task RenameFolder(FolderUpdateDto folderUpdateDto);
	}
}
