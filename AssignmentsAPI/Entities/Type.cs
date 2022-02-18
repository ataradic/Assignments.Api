using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssignmentsAPI.Entities
{
    public class Type
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Assignment> AssignmentType { get; set; }
    }
}