using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OriginFinancial.CodingChallenge.AppService.ViewModel
{
    public class RiskQuestionViewModel
    {
        public int ID { get; set; }

        [Display(Name = "Question")]
        public string Question { get; set; }

        [Display(Name = "Answer")]
        public int Answer { get; set; }

        [JsonIgnore]
        public int StatusID { get; set; }

        public enum Status
        {
            Active = 1,
            Inactive = 2,
        }

        [Display(Name = "Status")]
        public string strStatus
        {
            get
            {
                return Enum.GetName(typeof(Status), StatusID);
            }
        }

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
