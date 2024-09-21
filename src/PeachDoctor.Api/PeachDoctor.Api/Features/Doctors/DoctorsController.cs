using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PeachDoctor.Api.Features.Doctors.Commands.AddDoctor;
using PeachDoctor.Api.Features.Doctors.Commands.UpdateDoctor;
using PeachDoctor.Api.Features.Doctors.Models;
using PeachDoctor.Api.Features.Doctors.Queries.GetDoctorById;
using PeachDoctor.Api.Features.Doctors.Queries.GetDoctors;

namespace PeachDoctor.Api.Features.Doctors
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DoctorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorDto>>> GetDoctors([FromQuery] GetDoctors query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorDto>> GetDoctor(Guid id)
        {
            var query = new GetDoctorById { Id = id };
            var result = await _mediator.Send(query);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<DoctorDto>> AddDoctor(AddDoctor command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetDoctor), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> UpdateDoctor(Guid id, UpdateDoctor command)
        {
            if (id != command.Id)
                return BadRequest("Doctor ID mismatch.");

            var result = await _mediator.Send(command);
            if (!result)
                return NotFound();

            return NoContent();
        } 
    }
}
