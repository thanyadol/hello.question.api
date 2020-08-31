using System;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using hello.question.api.Services;
using hello.question.api.Models;
using hello.question.api.Models.Gateway;

namespace hello.question.api.Controllers
{
    //[Authorize]
    //[ServiceFilter(typeof(EnsureUserAuthorizeInAsync))]
    [ApiVersion("1.0")]
    [Route("api/{version:apiVersion}/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _answerService;
        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService ?? throw new ArgumentNullException(nameof(answerService));
        }

        //
        // Summary:
        //      post participant answer of subquestion
        //
        // Returns:
        //     list of Answer
        //
        [EnableCors("AllowCors")]
        [Route("post")]
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<AnswerParams>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IEnumerable<AnswerParams>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> BatchCreateAsync(AnswerParams param)
        {
            var entities = await _answerService.BatchCreateAsync(param);
            return Ok(entities);
        }


        //
        // Summary:
        //      return basic list of Answer
        //
        // Returns:
        //     list of Answer
        //
        [EnableCors("AllowCors")]
        [Route("list")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Answer>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IEnumerable<Answer>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListAsync()
        {
            var entities = await _answerService.ListAsync();
            return Ok(entities);
        }

    }
}