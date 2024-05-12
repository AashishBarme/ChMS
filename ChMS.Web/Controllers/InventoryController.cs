using Chms.Application.Common.Interface;
using Chms.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ChMS.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class InventoryController : ControllerBase
{
    public readonly IInventoryService _service;
    public InventoryController(IInventoryService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] Inventory request)
    {
        var response = await _service.Create(new Inventory{
            Name = request.Name,
            Description = request.Description,
            Code = request.Code,
            Quantity = request.Quantity
        });
        return Ok(response);
    }


    [HttpPut]
    public async Task<ActionResult> Update([FromBody] Inventory request)
    {
        await _service.Update(new Inventory{
            Id = request.Id,
            Name = request.Name,
            Description = request.Description,
            Code = request.Code,
            Quantity = request.Quantity
        });
        return Ok();
    }

     [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        _service.Delete(id);
        return Ok();
    }

    [HttpGet("{id}")]
    public ActionResult Get(int id)
    {
        return Ok(_service.Get(id));
    }

    [HttpGet("list")]
    public ActionResult List()
    {
        return Ok(_service.List());
    }

}