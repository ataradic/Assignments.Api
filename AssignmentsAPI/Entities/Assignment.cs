using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentsAPI.Entities
{
    public class Assignment
    {
        public int Id { get; set; }
        [ForeignKey("AssignmentType")]
        public int TypeId { get; set; }
        
        public string AssignmentName { get; set; }
       
        public string AssignmentDescription { get; set; }
        public bool IsRepeated { get; set; }
       
        public bool IsDone { get; set; } = false;
        
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
       
        public virtual Type AssignmentType { get; set; }

    }
}