using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MurderWithFriendsAPI.Services;

namespace MurderWithFriendsAPI.Controllers
{

	[Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

		private AuthService _authService;

		public AuthenticationController(AuthService authService)
		{		
			_authService = authService;
		}

		[HttpGet("{userName}/{password}")]		
		public bool GetAuthentication(string userName, string password)

		{
			return _authService.IsAuthorized(userName, password);
		}
	}
}