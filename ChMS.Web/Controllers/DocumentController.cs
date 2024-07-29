using Chms.Application.Common.Interface;
using Chms.Domain.Entities;
using ChMS.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Dapper.SqlMapper;
using Chms.Domain.ViewModels.Inventories;

namespace ChMS.Web.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class DocumentController : ControllerBase
{
    public readonly IDocumentService _service;
    private readonly IFileUploadService _fileUploadService;
    public DocumentController(IDocumentService service, IFileUploadService fileUploadService)
    {
        _service = service;
        _fileUploadService = fileUploadService;
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromForm] CreateInventoryVM request)
    {
        // var entity = new Inventory
        // {
        //     Name = request.Name,
        //     Description = request.Description,
        //     Code = request.Code,
        //     Quantity = request.Quantity
        // };
        // if (request.ImageFile!= null)
        // {
        //     entity.Image = await _fileUploadService.UploadFile(request.ImageFile);
        // }
        // Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(entity));
        // var response = await _service.Create(entity);
        return Ok();
    }


    [HttpPut]
    public async Task<ActionResult> Update([FromForm] EditInventoryVM request)
    {
        // var entity = new Inventory
        // {
        //     Id = request.Id,
        //     Name = request.Name,
        //     Description = request.Description,
        //     Code = request.Code,
        //     Quantity = request.Quantity,
        //     Image = request.Image
        // };
        // if (request.ImageFile != null)
        // {
        //     entity.Image = await _fileUploadService.UploadFile(request.ImageFile);
        // }
        // await _service.Update(entity);
        return Ok();
    }

     [HttpDelete("{id}")]
    public ActionResult Delete(string id)
    {
        _service.Delete(id);
        return Ok();
    }

    [HttpGet("{id}")]
    public ActionResult Get(string id)
    {
        return Ok(_service.Get(id));
    }

    [HttpGet("list")]
    public ActionResult List([FromQuery] FilterQueryVm filterQuery)
    {
        // FilterVm filterVm = new FilterVm(){
        //     Name = filterQuery.Name,
        //     Code = filterQuery.Code,
        //     Offset = filterQuery.Offset,
        //     Limit = filterQuery.Limit,
        // };


        // InventoryListResponseVm response = new(){
        //     Items = _service.List(filterVm),
        //     TotalDataCount = _service.TotalDataCount(filterVm)
        // };
        return Ok();
    }
}