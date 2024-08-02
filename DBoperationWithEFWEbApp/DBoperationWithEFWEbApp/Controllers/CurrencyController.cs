using DBoperationWithEFWEbApp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web.Http.Cors;

namespace DBoperationWithEFWEbApp.Controllers
{

	[Route("api/Currencies")]
	[ApiController]
	public class CurrencyController : ControllerBase
	{
		
		private AppDBContext _appDBContext;

		public CurrencyController(AppDBContext appDBContext) 
		{ 
			_appDBContext=appDBContext;

		}
		//[HttpGet("")]
		/***
		public IActionResult GetAllCurrencies()
		{
			//https://www.youtube.com/watch?v=FxpRqm6uhHY&list=PLak2C883P4cUfJpBRakIIIonC83w64mtV&index=6
			//var resultCurrency = _appDBContext.Currencies.ToList();
			var resultCurrency = from Currencies in _appDBContext.Currencies
								 select Currencies;


			return Ok(resultCurrency.ToList());
		}
		*/


		[HttpGet("")]
		public async Task<IActionResult> GetAllCurrencies()
		{
		//var resultCurrency =await _appDBContext.Currencies.ToListAsync();
		var resultCurrency =await (from Currencies in _appDBContext.Currencies
							 select Currencies).ToListAsync();


		return Ok(resultCurrency);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetAllCurrrenciesByIDAsyn([FromRoute] int id)
		{
			var resultCurrency =await _appDBContext.Currencies.FindAsync(id);
			return Ok(resultCurrency);
		}

		// POST: api/Products
		[HttpPost("")]
		public async Task<ActionResult<Currency>> PostCurrrencies(Currency currency)
		{
			_appDBContext.Currencies.Add(currency);
			await _appDBContext.SaveChangesAsync();

			return CreatedAtAction("GetProduct", new { id = currency.id }, currency);
		}


	}
}
