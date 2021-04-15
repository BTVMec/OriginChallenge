using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OriginFinancial.CodingChallenge.Domain.Entity
{
    public class Contract
    {
        [Key]
        [Column(TypeName = "int")]
        public int ID { get; set; }

        [Column(TypeName = "int")]
        public int AutoInsuranceID { get; set; }

        [Column(TypeName = "int")]
        public int DisabilityInsuranceID { get; set; }

        [Column(TypeName = "int")]
        public int HomeInsuranceID { get; set; }

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
