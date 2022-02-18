using System;
using System.ComponentModel.DataAnnotations;

namespace AssignmentsAPI.DTOs
{
    public class CreateAssignmentDto
    {
        [Required]
        public int TypeId { get; set; }
        [Required]
        public string AssignmentName { get; set; }
        [Required]
        public string AssignmentDescription { get; set; }
        [Required]
        public bool IsRepeated { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}