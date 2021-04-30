using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;

namespace WebApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private AppDbContext dbContext;
		public WeatherForecastController(AppDbContext dbContext)
		{
			this.dbContext = dbContext;

		}

		[HttpGet]
		public IActionResult Get()
		{
			var folders = dbContext.Folders.Where(c => c.FolderType == 0).Include(a=>a.Children).Where(a=>a.ParentId == 1 && a.UserId == 3);
			return Ok(folders);
		}
	}
}
