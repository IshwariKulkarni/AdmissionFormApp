using AdmissionForm.Dto;
using AdmissionForm.Interface;
using AdmissionForm.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdmissionForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IStateRepo _stateRepo;

        public StateController(IStateRepo stateRepository)
        {
            _stateRepo = stateRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<State>>> GetStates()
        {
            var states = await _stateRepo.GetStatesAsync();
            return Ok(states);
        }

        [HttpPost]
        public async Task<ActionResult<State>> AddState(StateDto stateDto)
        {
            var newState = new State
            {
                StateName = stateDto.StateName
            };

            await _stateRepo.AddStateAsync(newState);

            return CreatedAtAction("GetStates", new { id = newState.StateId }, newState);
        }

        [HttpGet]
        [Route("GetStateById/{stateId}")]
        public ActionResult GetStateById(int stateId)
        {
            var state = _stateRepo.GetStateById(stateId);

            if (state == null)
            {
                return NotFound();
            }

            return Ok(state);
        }
    }
}
