using Application;
using Application.EntitiesOperations.Message;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.@base;

namespace Presentation.Controllers.Message
{
    public class MessageController : ApiController
    {
        private readonly IMessageServices _MessageServices;
        public MessageController(IMessageServices MessageServices)
        {
            _MessageServices = MessageServices;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateMessageDto input, CancellationToken cancellationToken = default)
        {

            return Ok(await _MessageServices.Create(input, cancellationToken));

        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            return Ok(await _MessageServices.Read(cancellationToken));

        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateMessageDto input, CancellationToken cancellationToken = default)
        {
            var res = await _MessageServices.Update(input, cancellationToken);

            if (res.IsSuccess)
                return Ok(res.Value);
            else
                return BadRequest(res.Error.Message);

        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm] DeleteTable input, CancellationToken cancellationToken = default)
        {
            var res = await _MessageServices.Delete(input, cancellationToken);

            if (res.IsSuccess)
                return Ok(res.Value);
            else
                return BadRequest(res.Error.Message);

        }

    }
}



