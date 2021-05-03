using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using WebApi.Data;
using WebApi.Dtos;
using WebApi.Models;

namespace WebApi.Services
{
	public class FolderService : IFolderService
	{
		private AppDbContext dbContext;
		private IMapper mapper; 
		public FolderService(AppDbContext dbContext, IMapper mapper)
		{
			this.dbContext = dbContext;
			this.mapper = mapper;
		}

		public async Task<int> CreateFolder(FolderCreationDto folderCreationDto)
		{
			var folder = this.mapper.Map<Folder>(folderCreationDto);
			await this.dbContext.Folders.AddAsync(folder);
			await this.dbContext.SaveChangesAsync();
			return folder.Id;
		}

		public async Task<FolderItems> GetSubfolders(int parentId)
		{
			var folder = await dbContext.Folders.Include(a=>a.Children).Include(a=>a.FileUploads).FirstOrDefaultAsync(a=>a.Id == parentId);
			return new FolderItems
			{
				FileUploads = this.mapper.Map<List<FileUploadListItem>>(folder.FileUploads),
				Children = this.mapper.Map<List<FolderListItemDto>>(folder.Children)
			};
		}

		public async Task MoveFolder(int ToId, int id)
		{
			var folder = await this.dbContext.Folders.FirstOrDefaultAsync(folder => folder.Id == id && folder.UserId == 3);
			folder.ParentId = ToId;
			dbContext.Folders.Update(folder);
			await dbContext.SaveChangesAsync();
		}

		public async Task RemoveFolder(int id)
		{
			var folder = await this.dbContext.Folders.SingleOrDefaultAsync(f => f.Id == id);
			if (folder != null)
			{
			 await	RemoveChildren(folder.Id);
			 this.dbContext.Folders.Remove(folder);
			 await this.dbContext.SaveChangesAsync();
			}
			
		}

		public async Task RenameFolder(FolderUpdateDto folderUpdateDto)
		{
			if (folderUpdateDto.FolderId != 1 && folderUpdateDto.FolderId != 2)
			{
				var folderFromDb = await this.dbContext.Folders.SingleOrDefaultAsync(folder => folder.Id == folderUpdateDto.FolderId);
				folderFromDb.Name = folderUpdateDto.FolderName;
				this.dbContext.Folders.Update(folderFromDb);
				await this.dbContext.SaveChangesAsync();
			}
		}


		async Task RemoveChildren(int id)
		{
			var children = await this.dbContext.Folders.Where(c => c.ParentId == id).ToListAsync();
			foreach (var child in children)
			{
				var folder = await this.dbContext.Folders.SingleOrDefaultAsync(f => f.Id == child.Id && child.UserId ==3);
				if (folder != null)
				{
					await RemoveChildren(child.Id);
					this.dbContext.Folders.Remove(child);
					await this.dbContext.SaveChangesAsync();
				}
				

			}
		}
	}
}
