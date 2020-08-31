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
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService ?? throw new ArgumentNullException(nameof(questionService));
        }

        //
        // Summary:
        //      return basic list of question
        //
        // Returns:
        //     list of question
        //
        [EnableCors("AllowCors")]
        [Route("get")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<QuestionParams>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IEnumerable<QuestionParams>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRemainBySessionAsync(Guid sessionid)
        {
            var entities = await _questionService.GetRemainBySessionAsync(sessionid);
            return Ok(entities);
        }


        //
        // Summary:
        //      return basic list of question
        //
        // Returns:
        //     list of question
        //
        [EnableCors("AllowCors")]
        [Route("list")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Question>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(IEnumerable<Question>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListAsync()
        {
            var entities = await _questionService.ListAsync();
            return Ok(entities);
        }

    }
}