namespace Candidate_BlazorWASM.Shared
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Level")]
    public class Level
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LevelId { get; set; }

        public string LevelName { get; set; }

        public virtual ICollection<Candidate> Candidates { get; set; }
    }
}
