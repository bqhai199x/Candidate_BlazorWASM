namespace Candidate_BlazorWASM.Shared
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Candidate")]
    public class Candidate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CandidateId { get; set; }

        [Required(ErrorMessage = "Vị trí không được để trống!")]
        public int? PositionId { get; set; }

        [Required(ErrorMessage = "Chức danh không được để trống!")]
        public int? LevelId { get; set; }

        [Required(ErrorMessage = "Tên không được để trống!")]
        public string FullName { get; set; }

        public string Birthday { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string IntroduceName { get; set; }

        public string CVPath { get; set; }

        public bool IsApplied { get; set; }

        public int Status { get; set; }

        [ForeignKey("LevelId")]
        public virtual Level Level { get; set; }

        [ForeignKey("PositionId")]
        public virtual Position Position { get; set; }

        public int InterContacted { get; set; }

        public DateTime? InterTime { get; set; }

        public string InterLocation { get; set; }

        public string InterNote { get; set; }

        public string MailTitle { get; set; }

        public string MailBody { get; set; }
    }
}
