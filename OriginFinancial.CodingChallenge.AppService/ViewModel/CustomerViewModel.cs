using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace OriginFinancial.CodingChallenge.AppService.ViewModel
{
    public class CustomerViewModel
    {
        public Guid ID { get; set; }

        [Display(Name = "Full name")]
        public string FullName { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Age")]
        public int Age { get; set; }

        [Display(Name = "Dependents")]
        public int Dependents { get; set; }

        [JsonIgnore]
        public int? House { get; set; }

        [JsonIgnore]
        public int? HouseOwnershipStatusID { get; set; }

        public enum HouseOwnershipStatus
        {
            Owned = 1,
            Mortgaged = 2
        }

        [JsonProperty("House")]
        [Display(Name = "House")]
        public string strHouseOwnershipStatus
        {
            get
            {
                if (HouseOwnershipStatusID.HasValue)
                    return Enum.GetName(typeof(HouseOwnershipStatus), HouseOwnershipStatusID);
                else
                    return "";
            }
        }

        [Display(Name = "Income")]
        public int Income { get; set; }

        [JsonIgnore]
        public int MaritalStatusID { get; set; }

        public enum MaritalStatus
        {
            Married = 1,
            Single = 2
        }

        [JsonProperty("MaritalStatus")]
        [Display(Name = "MaritalStatus")]
        public string strMaritalStatus
        {
            get
            {
                return Enum.GetName(typeof(MaritalStatus), MaritalStatusID);
            }
        }

        [JsonIgnore]
        public int? Vehicle { get; set; }

        [JsonProperty("Vehicle")]
        [Display(Name = "Vehicle")]
        public int? VehicleYear { get; set; }

        [Display(Name = "Created")]
        public DateTime Created { get; set; }

        [Display(Name = "Modified")]
        public DateTime? Modified { get; set; }
    }
}
