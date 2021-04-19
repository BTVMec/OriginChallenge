using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace OriginFinancial.CodingChallenge.AppService.ViewModel
{
    public class CustomerRiskQuestionViewModel
    {
        public int ID { get; set; }

        [Display(Name = "Question")]
        public string Question { get; set; }

        [Display(Name = "Answer")]
        public bool Answer { get; set; }

        [Display(Name = "Created")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss}")]
        public DateTime Created { get; set; }

        [Display(Name = "Modified")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss}")]
        public DateTime? Modified { get; set; }
    }
}
