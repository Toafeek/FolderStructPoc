using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dtos;

namespace WebApi.Services
{
	public interface IFolderService
	{
		public Task<int> CreateFolder(FolderCreationDto folderCreationDto);

		public Task<IEnumerable<FolderListItemDto>> GetSubfolders(int parentId);

		public Task MoveFolder(int ToId, int id);

		public Task RemoveFolder(int id);
	}
}
