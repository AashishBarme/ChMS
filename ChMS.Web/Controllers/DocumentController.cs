using Chms.Application.Common.Interface;
using Chms.Domain.Entities;
using ChMS.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Dapper.SqlMapper;
using Chms.Domain.ViewModels.Documents;

namespace ChMS.Web.Controllers;

[ApiController]
[Route("[controller]")]
//[Authorize]
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
    public async Task<ActionResult<string>> Create([FromForm] CreateDocumentVm request)
    {      
        var entity = new Document
        {
            Name = request.Name,
            Description = request.Description,
            Type = request.File.ContentType,
            Size = request.File.Length.ToString()
        };
        if (request.File!= null)
        {
            entity.Path = await _fileUploadService.UploadFile(request.File);
        }
        Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(entity));
        var response = await _service.Create(entity);
        return Ok(response);
    }


    [HttpPut]
    public async Task<ActionResult> Update([FromForm] EditDocumentVm request)
    {
        var entity = new Document
        {
            Id = request.Id,
            Name = request.Name,
            Description = request.Description,
        };
        if (request.File != null)
        {
            entity.Path = await _fileUploadService.UploadFile(request.File);
            entity.Type = request.File.ContentType;
            entity.Size = request.File.Length.ToString();
        }
        Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(entity));
        await _service.Update(entity);
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
    public ActionResult List([FromQuery] DocFilterQueryVm filterQuery)
    {
        FilterVm filterVm = new()
        {
            Name = filterQuery.Name,
            CreatedDate = filterQuery.CreatedDate,
            Offset = filterQuery.Offset,
            Limit = filterQuery.Limit,
        };


        DocListResponseVm response = new()
        {
            Items = _service.List(filterVm),
            TotalDataCount = _service.TotalDataCount(filterVm)
        };
        return Ok(response);
    }
}