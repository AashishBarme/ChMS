using Microsoft.AspNetCore.Mvc;
using Chms.Application.Common.Interface;
using Chms.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using ChMS.Web.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChMS.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class MemberController : ControllerBase
    {
        public readonly IMemberService _service;
        public readonly IFileUploadService _uploadService;
        public MemberController(IMemberService service, IFileUploadService uploadService)
        {
            _service = service;
            _uploadService = uploadService;
        }


        [HttpPost]
        public async Task<ActionResult<int>> Create([FromForm] CreateMemberVm request)
        {
            var entity = new Member
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                MembershipDate = request.MembershipDate,
                BaptizedDate    = request.BaptizedDate,
                PermanentAddress = request.PermanentAddress,
                TemporaryAddress   = request.TemporaryAddress,
                Gender  = request.Gender,
                MiddleName = request.MiddleName,
                PhoneNumber = request.PhoneNumber,
                SecondaryPhoneNumber = request.SecondaryPhoneNumber,
                BirthDate  = request.BirthDate,
                Occupation = request.Occupation
            };

            if (request.PhotoFile != null)
            {
                entity.Photo = await _uploadService.UploadFile(request.PhotoFile);
            }

            var response = await _service.Create(entity);
            return Ok(response);
        }


        [HttpPut]
        public async Task<ActionResult> Update([FromForm] EditMemberVm request)
        {
             Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(request));
            var entity = new Member
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                MembershipDate = request.MembershipDate,
                BaptizedDate = request.BaptizedDate,
                PermanentAddress = request.PermanentAddress,
                TemporaryAddress = request.TemporaryAddress,
                Gender = request.Gender,
                MiddleName = request.MiddleName,
                PhoneNumber = request.PhoneNumber,
                SecondaryPhoneNumber = request.SecondaryPhoneNumber,
                BirthDate = request.BirthDate,
                Photo = request.Photo,
                Occupation = request.Occupation
            };

            if (request.PhotoFile != null)
            {
                entity.Photo = await _uploadService.UploadFile(request.PhotoFile);
            }
             Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(entity));
            await _service.Update(entity);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            _service.Delete(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult Get(Guid id)
        {
            return Ok(_service.Get(id));
        }

        [HttpGet("list")]
        public ActionResult List()
        {
            return Ok(_service.List());
        }
    }
}
