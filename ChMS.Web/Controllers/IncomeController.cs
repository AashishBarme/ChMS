using Microsoft.AspNetCore.Mvc;
using Chms.Application.Common.Interface;
using Chms.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using ChMS.Web.ViewModels;
using Income = Chms.Domain.Entities.Income;
using Chms.Domain.ViewModels.IncomeExpense;
using Microsoft.AspNetCore.Identity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChMS.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Authorize]
    public class IncomeController : ControllerBase
    {
        public readonly IIncomeService _service;
        public readonly IFileUploadService _uploadService;
        public IncomeController(IIncomeService service, IFileUploadService uploadService)
        {
            _service = service;
            _uploadService = uploadService;
        }


        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] AddIncome request)
        {
           
            if(request.Income.Count == 0 || String.IsNullOrEmpty(request.Date.ToString()))
            {
                return Ok("Nothing found");
            }

            foreach(var income in request.Income)
            {
                Income entity = new()
                {
                    Category = income.Category,
                    Amount = income.Amount,
                    Date = request.Date,
                    MemberId = income.MemberId,
                    Description = income.Description,
                    //CreatedBy = User.Identity.GetUserId()
                };
                await _service.Create(entity);
            }
            
            return Ok();
        }


        [HttpPut]
        public async Task<ActionResult> Update([FromBody] EditIncome request)
        {
            if (request.Income.Count == 0 || String.IsNullOrEmpty(request.Date.ToString()))
            {
                return Ok("Nothing found");
            }

            foreach (var income in request.Income)
            {
                Income entity = new()
                {
                    Id = income.Id,
                    Category = income.Category,
                    Amount = income.Amount,
                    Date = request.Date,
                    MemberId = income.MemberId,
                    Description = income.Description
                };
                await _service.Update(entity);
            }

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
        public ActionResult List([FromQuery] IncomeFilterQueryVm filterQuery)
        {
            FilterVm filterVm = new(){
                DateTime = filterQuery.Date,
            };

            //MemberListResponseVm response = new(){
            //    Items = _service.List(filterVm),
            //    TotalDataCount = _service.TotalDataCount(filterVm)
            //};
            return Ok();
        }
    }
}
