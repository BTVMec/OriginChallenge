using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OriginFinancial.CodingChallenge.Domain.Entity
{
    public class CustomerRiskQuestion
    {
        [Key]
        [Column(TypeName = "int")]
        public int ID { get; set; }

        [Column(TypeName = "int")]
        public int RiskQuestionAnswer { get; set; }

        #region Tracking.
        [Column(TypeName = "datetime")]
        public DateTime Created { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? Modified { get; set; }
        #endregion

        #region Foreign keys.
        [Column(TypeName = "char(36)")]
        public Guid CustomerID { get; set; }

        [Column(TypeName = "int")]
        public int RiskQuestionID { get; set; }

        [Column(TypeName = "int")]
        public int ContractID { get; set; }
        #endregion

        #region Foreign objects.
        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }

        [ForeignKey("RiskQuestionID")]
        public virtual RiskQuestion RiskQuestion { get; set; }

        [ForeignKey("ContractID")]
        public virtual Contract Contract { get; set; }
        #endregion
    }
}
