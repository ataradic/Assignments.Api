using AssignmentsAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssignmentsAPI.DTOs;
using AssignmentsAPI.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace AssignmentsAPI.Data
{
    public class AssignmentsRepository : IAssignmentsRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public AssignmentsRepository(DataContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public Assignment AddAssignment(Assignment assignment)
        {
           return _context.Assignments.Add(assignment).Entity;
           
        }

        public void DeleteAssignment(Assignment assignment)
        {
            _context.Assignments.Remove(assignment);
        }

        public async Task<Assignment> GetAssignment(int assignmentId)
        {
            return await _context.Assignments.Include(assignment=>assignment.AssignmentType).
                Where(assignment=> assignment.Id==assignmentId).FirstOrDefaultAsync();
        }

        public async Task<PagedList<AssignmentDto>> GetAssignments(UserParamsDto userParamsDto)
        {
            try
            {

            var query = _context.Assignments.AsQueryable();
            query = query.OrderByDescending(a => a.StartDate)
               .Where(a => !a.IsDone);
            return await PagedList<AssignmentDto>.CreateAsync(query.ProjectTo<AssignmentDto>(_mapper.ConfigurationProvider).AsNoTracking()
            , userParamsDto.PageNumber, userParamsDto.PageSize);

            }
            catch (Exception e)
            {

                throw e;
            }
        }

       
        public async Task<List<Entities.Type>> GetTypes()
        {
            return await _context.AssignmentsTypes.ToListAsync();
        }
        public async Task<int> SetAssignmentToDone(int assignmentId)
        {
            var assignment=await GetAssignment(assignmentId);
            if (assignment == null) return 404;
            if (assignment.IsDone) return 400;
            assignment.IsDone = true;
Update(assignment);
            return 200;
        }

        public void Update(Assignment assignment)
        {
            _context.Entry(assignment).State = EntityState.Modified;
        }
        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }


    }
}