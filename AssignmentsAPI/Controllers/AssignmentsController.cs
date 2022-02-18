using System.Collections.Generic;
using System.Threading.Tasks;
using AssignmentsAPI.Data;
using AssignmentsAPI.DTOs;
using AssignmentsAPI.Entities;
using AssignmentsAPI.Extensions;
using AssignmentsAPI.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentsAPI.Controllers
{
    public class AssignmentsController : BaseApiController
    {
        private readonly IAssignmentsRepository _assignmentsRepository;
        private readonly IMapper _mapper;
        private object users;

        public AssignmentsController(IAssignmentsRepository assignmentsRepository, IMapper mapper)
        {
            _mapper = mapper;
            _assignmentsRepository = assignmentsRepository;
        }

        [HttpPost]
        public async Task<ActionResult<AssignmentDto>> CreateAssignment([FromBody]CreateAssignmentDto createAssignmentDto)
        {
            try
            {
            if (createAssignmentDto == null) return BadRequest("You canot add a null assignment");

            var assignment = _mapper.Map<Assignment>(createAssignmentDto);
              assignment.TypeId = assignment.TypeId>3|| assignment.TypeId < 1 ?  1 : assignment.TypeId;
              
            assignment= _assignmentsRepository.AddAssignment(assignment);

                if (await _assignmentsRepository.SaveAllAsync())
                {
                    Assignment Createdassignment = await _assignmentsRepository.GetAssignment(assignment.Id);
                    return _mapper.Map<AssignmentDto>(Createdassignment);
                }
           
            return BadRequest("Failed to add assignment");
            }
            catch (System.Exception e)
            {

                throw e;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AssignmentDto>> GetAssignment(int id)
        {
            var model = await _assignmentsRepository.GetAssignment(id);

            if (model == null)
            {
                return NotFound();
            }

            return _mapper.Map<AssignmentDto>(model); 
        }
        [HttpGet(("getTypes"))]
        public async Task<IEnumerable<TypeDto>> GetTypes()
        {
            var types = await _assignmentsRepository.GetTypes();
            return _mapper.Map<List<TypeDto>>(types);
        }

        [HttpPost("getAssignments")]
        public async Task<ActionResult<IEnumerable<AssignmentDto>>> GetAssignments([FromBody] UserParamsDto userParamsDto)
        {
           
            var assignments = await _assignmentsRepository.GetAssignments(userParamsDto);
            Response.AddPaginationHeader(assignments.CurrentPage, assignments.PageSize, assignments.ToatalCount, assignments.TotalPages);
            return Ok(assignments);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssignment(int id)
        {
            var model = await _assignmentsRepository.GetAssignment(id);

            if (model == null) return NotFound();
            

            _assignmentsRepository.DeleteAssignment(model);

            if (await _assignmentsRepository.SaveAllAsync()) return Ok();

            return BadRequest("Failed to delete assignment");
            
        }
       
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDoneAssignment(int id)
    {
            var code =  await _assignmentsRepository.SetAssignmentToDone(id);
            
            if(code==404) return NotFound();
            if (code == 400) return BadRequest("This assignment is already done");
            
            if (code==200&&await _assignmentsRepository.SaveAllAsync()) return NoContent();
            return BadRequest("Failed to set assignment to done");
    } }

}