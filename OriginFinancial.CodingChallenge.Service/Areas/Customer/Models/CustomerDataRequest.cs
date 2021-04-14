using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace OriginFinancial.CodingChallenge.Service.Areas.Customer.Models
{
    public class CustomerDataRequest
    {
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(100, ErrorMessage = "The field {0} must have between {2} and {1} chars.", MinimumLength = 5)]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "The {0} field allows only letters.")]
        public string FullName { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(60, ErrorMessage = "The field {0}'s maximum length is {1}.")]
        [EmailAddress(ErrorMessage = "The field {0} must be a valid e-mail address.")]
        public string Email { get; set; }

        [Display(Name = "Age")]
        [Required(ErrorMessage = "The {0} field is required.")]
        [Range(18, 100, ErrorMessage = "The field {0} value's must be between {1} and {2}.")]
        public int Age { get; set; }

        [Display(Name = "Dependents")]
        [Required(ErrorMessage = "The {0} field is required.")]
        [Range(0, 10, ErrorMessage = "The field {0} value's must be between {1} and {2}.")]
        public int Dependents { get; set; }

        [Display(Name = "House")]
        public House House { get; set; }

        [Display(Name = "Income")]
        [Required(ErrorMessage = "The {0} field is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "The field {0} value's must be equal or greater than to {1}.")]
        public int Income { get; set; }

        [Display(Name = "MaritalStatus")]
        [Required(ErrorMessage = "The {0} field is required.")]
        [Range(0, 1, ErrorMessage = "The field {0} value's must be equal to {1} or {2}.")]
        public int MaritalStatusID { get; set; }

        [Display(Name = "Vehicle")]
        public Vehicle Vehicle { get; set; }
    }

    public class House
    {
        [JsonProperty("OwnershipStatus")]
        [Display(Name = "OwnershipStatus")]
        [Range(0, 1, ErrorMessage = "The field {0} value's must be equal to {1} or {2}.")]
        public int? HouseOwnershipStatusID { get; set; }
    }

    public class Vehicle
    {
        [JsonProperty("Year")]
        [Display(Name = "Year")]
        [Range(1900, int.MaxValue, ErrorMessage = "The field {0} value's must be equal or greater than to {1}.")]
        public int? VehicleYear { get; set; }
    }
}
