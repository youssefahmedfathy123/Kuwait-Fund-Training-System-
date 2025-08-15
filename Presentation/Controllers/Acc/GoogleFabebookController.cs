//using Application.Abstractions.Auth;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Authentication.Facebook;
//using Microsoft.AspNetCore.Authentication.Google;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Presentation.Controllers.@base;
//using System.Reflection.Metadata;
//using System.Security.Claims;

//public class ExternalAuthController : ApiController
//{
//    private readonly IExternalAuthService _externalAuthService;

//    public ExternalAuthController(IExternalAuthService externalAuthService)
//    {
//        _externalAuthService = externalAuthService;
//    }


//    [HttpGet("google-login")]
//    public IActionResult GoogleLogin()
//    {
//        var redirectUrl = Url.Action(nameof(GoogleResponse));
//        var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
//        return Challenge(properties, GoogleDefaults.AuthenticationScheme);
//    }

//    #region ok
//    // user click to login -> /google-login ->((( /signin-google -> listen to the request and store the auth )))-> /google-response

//    //user click login -> /google-login -> Google -> Google OAuth -> /signin-google -> Google middleware handles it  -> Redirect to /google-response -> JWT
//    #endregion

//    [HttpGet("google-response")]
//    public async Task<IActionResult> GoogleResponse()
//    {
//        var result = await HttpContext.AuthenticateAsync("External");
//        if (!result.Succeeded)
//            return BadRequest("External authentication failed");

//        var email = result.Principal.FindFirst(ClaimTypes.Email)?.Value;
//        var name = result.Principal.FindFirst(ClaimTypes.Name)?.Value;

//        var jwt = await _externalAuthService.HandleExternalLoginAsync(email, name);

//        return Ok(new { Token = jwt });
//    }


//    [HttpGet("facebook-login")]
//    public IActionResult FacebookLogin()
//    {
//        var redirectUrl = Url.Action(nameof(FacebookResponse));
//        var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
//        return Challenge(properties, FacebookDefaults.AuthenticationScheme);
//    }

//    [HttpGet("facebook-response")]
//    public async Task<IActionResult> FacebookResponse()
//    {
//        var result = await HttpContext.AuthenticateAsync("External");
//        if (!result.Succeeded)
//            return BadRequest("External authentication failed");

//        var email = result.Principal.FindFirst(ClaimTypes.Email)?.Value;
//        var name = result.Principal.FindFirst(ClaimTypes.Name)?.Value;

//        var jwt = await _externalAuthService.HandleExternalLoginAsync(email, name);

//        return Ok(new { Token = jwt });
//    }


//    [HttpGet("logout-googleOrfacebook")]
//    public async Task<IActionResult> Logout()
//    {
//        await HttpContext.SignOutAsync();
//        await HttpContext.SignOutAsync("External");
//        return Ok("Signed out");
//    }

//}




