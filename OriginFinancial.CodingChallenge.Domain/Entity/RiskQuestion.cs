using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OriginFinancial.CodingChallenge.Domain.Entity
{
    public class RiskQuestion
    {
        [Key]
        [Column(TypeName = "int")]
        public int ID { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string Question { get; set; }

        [NotMapped]
        public bool Answer { get; set; }

        [Column(TypeName = "int")]
        public int StatusID { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Created { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? Modified { get; set; }
    }
}
