using Chms.Application.Common.Interface;
using ChMS.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace ChMS.Web.Controllers;
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _service;
    private readonly ICurrentUserService _currentUserService;
    public UserController(IUserService service, ICurrentUserService currentUserService)
    {
        _service = service;
        _currentUserService = currentUserService;
    }

    [HttpPut("update-password")]
    public async Task<ActionResult<bool>> UpdatePassword([FromBody] UpdatePassword request)
    {
        try
        {
            if(request.Id == 0)
            {
                request.Id = _currentUserService.UserId;
            }

            if(request.Password != request.ConfirmPassword)
            {
                return BadRequest("Password and Confirm Password doesn't match");
            }

            if(!request.Password.IsNullOrEmpty())
            {
                return await _service.UpdatePassword(request.Id, request.Password);
            }
            return BadRequest("Something went wrong");
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}