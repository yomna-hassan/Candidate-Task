using BussinessLayer.Services;
using BussinessLayer.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationLayer.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpPost]
        [Route("AddCandidate")]
        public async Task<ActionResult> AddCandidate(CandidateVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var res=await _candidateService.AddCandidate(model);
                    return Ok(res);

                }
                 catch(Exception e)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,e.Message);

                }
            }
            return BadRequest(ModelState.ValidationState);

        }
    }
}
