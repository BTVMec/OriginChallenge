using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OriginFinancial.CodingChallenge.Domain.Entity
{
    public class Contract
    {
        [Key]
        [Column(TypeName = "char(36)")]
        public Guid ID { get; set; }

        [Column(TypeName = "int")]
        public int GlobalRiskPoints { get; set; }

        [Column(TypeName = "int")]
        public int AutoInsurancePoints { get; set; }

        [Column(TypeName = "int")]
        public int AutoInsuranceID { get; set; }

        [Column(TypeName = "int")]
        public int DisabilityInsurancePoints { get; set; }

        [Column(TypeName = "int")]
        public int DisabilityInsuranceID { get; set; }

        [Column(TypeName = "int")]
        public int HomeInsurancePoints { get; set; }

        [Column(TypeName = "int")]
        public int HomeInsuranceID { get; set; }

        [Column(TypeName = "int")]
        public int LifeInsurancePoints { get; set; }

        [Column(TypeName = "int")]
        public int LifeInsuranceID { get; set; }

        #region Tracking.
        [Column(TypeName = "datetime")]
        public DateTime Created { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? Modified { get; set; }
        #endregion

        #region Foreign objects' relations.
        public virtual List<CustomerRiskQuestion> CustomerRiskQuestions { get; set; } 
        #endregion
    }
}
