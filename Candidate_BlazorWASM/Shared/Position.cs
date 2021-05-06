namespace Candidate_BlazorWASM.Shared
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Position")]
    public class Position
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PositionId { get; set; }

        public string PositionName { get; set; }

        public virtual ICollection<Candidate> Candidates { get; set; }
    }
}
