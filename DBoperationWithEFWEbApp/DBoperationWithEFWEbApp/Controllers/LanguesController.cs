using DBoperationWithEFWEbApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DBoperationWithEFWEbApp.Controllers
{
	[Route("api/Langues")]
	[ApiController]
	public class LanguesController : ControllerBase
	{
		private AppDBContext _appDBContext;
		public LanguesController(AppDBContext appDBContext) 
		{
			_appDBContext = appDBContext;
		}
		[HttpGet("")]
		public IActionResult GetLanguage()
		{
			var lang=_appDBContext.Languages.ToList();
			return Ok(lang);

		}
	}
}
