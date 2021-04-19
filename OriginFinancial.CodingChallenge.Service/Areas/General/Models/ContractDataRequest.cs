using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using OriginFinancial.CodingChallenge.AppService.Interface;
using OriginFinancial.CodingChallenge.AppService.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace OriginFinancial.CodingChallenge.Service.Areas.General.Models
{
    public class ContractDataRequest
    {
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(100, ErrorMessage = "The field {0} must have from {2} to {1} chars.", MinimumLength = 5)]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "The {0} field allows only letters and spaces.")]
        public string FullName { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(60, ErrorMessage = "The field {0}'s maximum length is {1}.")]
        [EmailAddress(ErrorMessage = "The field {0} must be a valid e-mail address.")]
        public string Email { get; set; }

        [Display(Name = "Age")]
        [Required(ErrorMessage = "The {0} field is required.")]
        [Range(18, 100, ErrorMessage = "The field {0} value's must be from {1} to {2}.")]
        public int Age { get; set; }

        [Display(Name = "Dependents")]
        [Required(ErrorMessage = "The {0} field is required.")]
        [Range(0, 10, ErrorMessage = "The field {0} value's must be from {1} to {2}.")]
        public int Dependents { get; set; }

        [Display(Name = "House")]
        public House House { get; set; }

        [Display(Name = "Income")]
        [Required(ErrorMessage = "The {0} field is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "The field {0} value's must be equal or greater than {1}.")]
        public int Income { get; set; }

        [JsonProperty("MaritalStatus")]
        [Display(Name = "MaritalStatus")]
        [Required(ErrorMessage = "The {0} field is required.")]
        [Range(1, 2, ErrorMessage = "The field {0} value's must be equal to {1} or {2}.")]
        public int MaritalStatusID { get; set; }

        [Display(Name = "Vehicle")]
        public Vehicle Vehicle { get; set; }

        [Display(Name = "Risk Questions")]
        public List<RiskQuestion> RiskQuestions { get; set; }
    }

    public class House
    {
        [JsonProperty("OwnershipStatus")]
        [Display(Name = "OwnershipStatus")]
        [Range(1, 2, ErrorMessage = "The field {0} value's must be equal to {1} or {2}.")]
        public int? HouseOwnershipStatusID { get; set; }
    }

    public class Vehicle
    {
        [JsonProperty("Year")]
        [Display(Name = "Year")]
        [Range(1900, 2021, ErrorMessage = "The field {0}'s value must be from {1} to {2}.")]
        public int? VehicleYear { get; set; }
    }

    public class RiskQuestion
    {
        [Display(Name = "Answer")]
        [Required(ErrorMessage = "The {0} field is required.")]
        public bool Answer { get; set; }
    }
}
