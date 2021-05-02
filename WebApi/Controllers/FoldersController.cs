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
	public class FoldersController : ControllerBase
	{
		private readonly IFolderService service;
		public FoldersController(IFolderService service)
		{
			this.service = service;
		}
		[HttpPost]
		public async Task<IActionResult> AddFolder(FolderCreationDto folderCreationDto)
		{
			return Ok( await  this.service.CreateFolder(folderCreationDto));
		}

		[HttpGet("{parentId}")]
		public async Task<IActionResult> GetFolders(int parentId)
		{
			return Ok(await this.service.GetSubfolders(parentId));
		}

		[HttpPut("{id}/MoveTo/toId")]
		public async Task<IActionResult> MoveFolder(int toId, int id)
		{
			 await this.service.MoveFolder(toId, id);
			return Ok();
		}

		[HttpPut]
		public async Task<IActionResult> RenameFolder(FolderUpdateDto folderUpdateDto)
		{
			await this.service.RenameFolder(folderUpdateDto);
			return Ok();
		}


		[HttpDelete("{id}")]
		public async Task<IActionResult> RemoveFolder(int id)
		{
			await this.service.RemoveFolder(id);
			return NoContent();
		}
	}
}
