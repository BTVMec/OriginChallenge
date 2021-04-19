using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using OriginFinancial.CodingChallenge.AppService.Interface;
using OriginFinancial.CodingChallenge.AppService.ViewModel;
using OriginFinancial.CodingChallenge.Service.Utils.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OriginFinancial.CodingChallenge.Service.Areas.General.Controllers
{
    [Area("Customer")]
    [Route("[controller]")]
    [ApiController]
    public class DomainController : CommonBaseController
    {
        private readonly IDomainAppService _domainAppService;

        public DomainController(IServiceProvider services)
        {
            _domainAppService = services.GetRequiredService<IDomainAppService>();
        }

        /// <summary>
        /// The method for listing the domain values considered for the system's properties.
        /// </summary>
        /// <returns>
        /// <list type="bullet">
        /// <item>
        /// <description>A <see cref="OkResult"/> with the list of values, if the process is successful;</description>
        /// </item>
        /// <item>
        /// <description>A <see cref="NotFoundResult"/> if the data is not found;</description>
        /// </item>
        /// <item>
        /// <description>A <see cref="ErrorResponse"/> is the process fails.</description>
        /// </item>
        /// </list>
        /// </returns>
        [AllowAnonymous]
        [HttpGet("")]
        [ProducesResponseType(typeof(SuccessResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(SuccessResponse), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public ActionResult List()
        {
            try
            {
                //Retrieving the list of static values named domain.
                List<DomainViewModel> domainsViewModel = _domainAppService.List();

                if (domainsViewModel?.Count() > 0)
                    return Ok(domainsViewModel);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(SetTrace(ex));
            }
        }
    }
}
