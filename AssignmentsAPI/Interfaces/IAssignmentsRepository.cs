using System.Collections.Generic;
using System.Threading.Tasks;
using AssignmentsAPI.DTOs;
using AssignmentsAPI.Entities;
using AssignmentsAPI.Helpers;

namespace AssignmentsAPI.Data
{
    public interface IAssignmentsRepository
    {
        Assignment AddAssignment(Assignment assignment);
        void DeleteAssignment(Assignment assignment);
        Task<Assignment> GetAssignment(int assignmentId);
        Task<PagedList<AssignmentDto>> GetAssignments(UserParamsDto userParamsDto);
        Task<List<Type>> GetTypes();
        Task<int> SetAssignmentToDone(int assignmentId);
        void Update(Assignment assignment);
        Task<bool> SaveAllAsync();
    }
}