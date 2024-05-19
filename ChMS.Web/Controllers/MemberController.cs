using Microsoft.AspNetCore.Mvc;
using Chms.Application.Common.Interface;
using Chms.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChMS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        public readonly IMemberService _service;
        public MemberController(IMemberService service)
        {
            _service = service;
        }


        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] Member request)
        {
            var response = await _service.Create(request);
            return Ok(response);
        }


        [HttpPut]
        public async Task<ActionResult> Update([FromBody] Member request)
        {
            await _service.Update(request);
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
}
