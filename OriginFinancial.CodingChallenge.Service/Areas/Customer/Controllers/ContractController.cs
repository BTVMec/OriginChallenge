using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using OriginFinancial.CodingChallenge.AppService.Interface;
using OriginFinancial.CodingChallenge.AppService.ViewModel;
using OriginFinancial.CodingChallenge.Service.Areas.Customer.Models;
using OriginFinancial.CodingChallenge.Service.Utils.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OriginFinancial.CodingChallenge.Service.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Route("[area]/[controller]")]
    [ApiController]
    public class ContractController : CommonBaseController
    {
        private readonly IContractAppService _contractAppService;

        public ContractController(IServiceProvider services)
        {
            _contractAppService = services.GetRequiredService<IContractAppService>();
        }

        /// <summary>
        /// The asynchronous method for users/customers to create a insurance contract by giving their personal informations.
        /// </summary>
        /// <param name="contractDataRequest">The object for the contract request information.</param>
        /// <returns>
        /// <list type="bullet">
        /// <item>
        /// <description>A <see cref="SuccessResponse"/> if the process is successful;</description>
        /// </item>
        /// <item>
        /// <description>A <see cref="ErrorResponse"/> if the process fails.</description>
        /// </item>
        /// </list>
        /// </returns>
        [AllowAnonymous]
        [HttpPost("")]
        [ProducesResponseType(typeof(SuccessResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody] ContractDataRequest contractDataRequest)
        {
            try
            {
                //Transforming the request model's customer properties to view model.
                CustomerViewModel customerViewModel = new CustomerViewModel
                {
                    FullName = contractDataRequest.FullName,
                    Email = contractDataRequest.Email,
                    Age = contractDataRequest.Age,
                    Dependents = contractDataRequest.Dependents,
                    Income = contractDataRequest.Income,
                    MaritalStatusID = contractDataRequest.MaritalStatusID,
                };

                //Setting the customer's house properties.
                if (contractDataRequest.House != null && contractDataRequest.House.HouseOwnershipStatusID.HasValue)
                {
                    customerViewModel.House = 1;
                    customerViewModel.HouseOwnershipStatusID = contractDataRequest.House.HouseOwnershipStatusID;
                }

                //Setting the customer's vehicle properties.
                if (contractDataRequest.Vehicle != null && contractDataRequest.Vehicle.VehicleYear.HasValue)
                {
                    customerViewModel.Vehicle = 1;
                    customerViewModel.VehicleYear = contractDataRequest.Vehicle.VehicleYear;
                }

                //Transforming the request model's risk question properties to view model.
                List<RiskQuestionViewModel> riskQuestions = contractDataRequest.RiskQuestions.Select(x => new RiskQuestionViewModel
                {
                    Answer = x.Answer
                }).ToList();

                //Registering the new contract.
                ContractViewModel contractViewModel = await _contractAppService.CreateAsync(customerViewModel, riskQuestions);

                //Checking result.
                if (contractViewModel != null)
                    return Created("", contractViewModel);
                else
                    return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(SetTrace(ex));
            }
        }
    }
}
