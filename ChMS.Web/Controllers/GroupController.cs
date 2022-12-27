using ChMS.Core.Application.Groups;
using ChMS.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ChMS.Web.Controllers;


[ApiController]
[Route("[controller]")]
public class GroupController : ControllerBase
{
    private readonly IGroupRepository _repository;

    public GroupController(IGroupRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateGroupVM request)
    {
        var response = await _repository.Create(new Group{
            Name = request.Name,
            Description = request.Description,
            FellowshipRoutine = request.FellowshipRoutine
        });
        return Ok(response);
    }
}
