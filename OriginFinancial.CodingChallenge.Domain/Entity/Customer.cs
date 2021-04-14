using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OriginFinancial.CodingChallenge.Domain.Entity
{
    public class Customer
    {
        [Key]
        [Column(TypeName = "char(36)")]
        public Guid ID { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string FullName { get; set; }

        [Column(TypeName = "varchar(60)")]
        public string Email { get; set; }

        [Column(TypeName = "int")]
        public int Age { get; set; }

        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }

        [Column(TypeName = "int")]
        public int Dependents { get; set; }

        [Column(TypeName = "int")]
        public int House { get; set; }

        [Column(TypeName = "int")]
        public int? HouseOwnershipStatusID { get; set; }

        [Column(TypeName = "int")]
        public int Income { get; set; }

        [Column(TypeName = "int")]
        public int MaritalStatusID { get; set; }

        [Column(TypeName = "int")]
        public int Vehicle { get; set; }

        [Column(TypeName = "int")]
        public int? VehicleYear { get; set; }

        #region Tracking.
        [Column(TypeName = "datetime")]
        public DateTime Created { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? Modified { get; set; }
        #endregion
    }
}
