using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OriginFinancial.CodingChallenge.AppService.ViewModel
{
    public class ContractViewModel
    {
        [JsonProperty("ContractSerialNumber")]
        [Display(Name = "Contract's serial number")]
        public Guid ID { get; set; }

        [Display(Name = "Customer information")]
        public CustomerViewModel CustomerInfo { get; set; }

        [Display(Name = "Risk questions")]
        public List<CustomerRiskQuestionViewModel> RiskQuestions { get; set; }

        [Display(Name = "Global risk points")]
        public int GlobalRiskPoints { get; set; }

        [Display(Name = "Insurance policies")]
        public InsurancePolicies InsurancePolicies { get; set; }

        [Display(Name = "Created")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss}")]
        public DateTime Created { get; set; }

        [Display(Name = "Modified")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss}")]
        public DateTime? Modified { get; set; }

        public enum Insurance
        {
            Ineligible = 1,
            Economic = 2,
            Regular = 3,
            Responsible = 4
        }
    }

    public class InsurancePolicies
    {
        [JsonIgnore]
        public int AutoID { get; set; }
        [JsonIgnore]
        public int AutoPoints { get; set; }
        [Display(Name = "Auto insurance policy")]
        public string Auto
        {
            get
            {
                if (AutoPoints.Equals(1))
                    return $"{ Enum.GetName(typeof(ContractViewModel.Insurance), AutoID)} ({AutoPoints.ToString().PadLeft(2, '0')} risk point)";
                else
                    return $"{ Enum.GetName(typeof(ContractViewModel.Insurance), AutoID)} ({AutoPoints.ToString().PadLeft(2, '0')} risk points)";
            }
        }

        [JsonIgnore]
        public int DisabilityID { get; set; }
        [JsonIgnore]
        public int DisabilityPoints { get; set; }
        [Display(Name = "Disability insurance policy")]
        public string Disability
        {
            get
            {
                if (DisabilityPoints.Equals(1))
                    return $"{ Enum.GetName(typeof(ContractViewModel.Insurance), DisabilityID)} ({DisabilityPoints.ToString().PadLeft(2, '0')} risk point)";
                else
                    return $"{ Enum.GetName(typeof(ContractViewModel.Insurance), DisabilityID)} ({DisabilityPoints.ToString().PadLeft(2, '0')} risk points)";
            }
        }

        [JsonIgnore]
        public int HomeID { get; set; }
        [JsonIgnore]
        public int HomePoints { get; set; }
        [Display(Name = "Home insurance policy")]
        public string Home
        {
            get
            {
                if (HomePoints.Equals(1))
                    return $"{ Enum.GetName(typeof(ContractViewModel.Insurance), HomeID)} ({HomePoints.ToString().PadLeft(2, '0')} risk point)";
                else
                    return $"{ Enum.GetName(typeof(ContractViewModel.Insurance), HomeID)} ({HomePoints.ToString().PadLeft(2, '0')} risk points)";
            }
        }

        [JsonIgnore]
        public int LifeID { get; set; }
        [JsonIgnore]
        public int LifePoints { get; set; }
        [Display(Name = "Life insurance policy")]
        public string Life
        {
            get
            {
                if (LifePoints.Equals(1))
                    return $"{ Enum.GetName(typeof(ContractViewModel.Insurance), LifeID)} ({LifePoints.ToString().PadLeft(2, '0')} risk point)";
                else
                    return $"{ Enum.GetName(typeof(ContractViewModel.Insurance), LifeID)} ({LifePoints.ToString().PadLeft(2, '0')} risk points)";
            }
        }

    }
}
