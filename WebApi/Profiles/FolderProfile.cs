using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WebApi.Dtos;
using WebApi.Models;

namespace WebApi.Profiles
{
	public class FolderProfile : Profile
	{
		public FolderProfile()
		{
			CreateMap<FolderCreationDto, Folder>().ReverseMap();
			CreateMap<Folder, FolderListItemDto>().ReverseMap();
			CreateMap<FileUploadListItem, FileUpload>().ReverseMap();
		}
	}
}
