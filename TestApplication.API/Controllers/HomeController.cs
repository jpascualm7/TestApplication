using Microsoft.AspNetCore.Mvc;

namespace TestApplication.API.Controllers
{
	[ApiController]
	[Route("api/")]
	public class HomeController : ControllerBase
	{
		/// <summary>
		/// Useful endpoint, return 200 if the API is running
		/// </summary>
		/// <response code="200">Returns 200 if API is running</response>
		[HttpGet]
		[Route("health", Name = nameof(Health))]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[Produces("application/json")]
		public IActionResult Health()
		{
			return Ok("API is running");
		}
	}
}
