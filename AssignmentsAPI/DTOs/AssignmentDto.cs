using System;
using System.ComponentModel.DataAnnotations;

namespace AssignmentsAPI.DTOs
{
    public class AssignmentDto
    {
        public int Id { get; set; }
        public string AssignmentName { get; set; }
        
        public string AssignmentDescription { get; set; }
        
        public bool IsRepeated { get; set; }
       
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsDone { get; set; } = false;
        public string AssignmentType { get; set; }

    }
}