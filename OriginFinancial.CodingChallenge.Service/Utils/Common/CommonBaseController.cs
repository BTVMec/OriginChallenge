using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace OriginFinancial.CodingChallenge.Service.Utils.Common
{
    /// <summary>
    /// "Override of the Controller Base for customized functions.
    /// </summary>
    public class CommonBaseController : ControllerBase
    {
        /// <summary>
        /// The method that sets a trace for an Exception.
        /// </summary>
        /// <param name="exception">The exception for the trace to be set by.</param>
        /// <returns>An <see cref="ErrorResponse"/> for the Exception's trace.</returns>
        [AllowAnonymous]
        [ApiExplorerSettings(IgnoreApi = true)]
        public ErrorResponse SetTrace(Exception exception)
        {
            try
            {
                //Starting the objects of the trace.
                ErrorResponse error = new ErrorResponse(400);
                string[] arrClassName, first, second;
                string className, methodName, baseEx, third;
                string sourceLine = "";

                //Checking the exception's declaring type for retrieving the class' name and the method's name.
                if (exception?.TargetSite?.DeclaringType?.DeclaringType != null)
                {
                    arrClassName = exception.TargetSite.DeclaringType.DeclaringType.FullName.Split(".");
                    methodName = exception.TargetSite.DeclaringType.Name.Split("<")[1].Split(">")[0].ToString();
                }
                else
                {
                    arrClassName = exception.TargetSite.DeclaringType.FullName.Split(".");
                    methodName = exception.TargetSite.Name;
                }

                //Setting the class' name.
                className = arrClassName[arrClassName.Length - 1];

                //Getting the exception's source line.
                baseEx = exception.StackTrace;
                first = baseEx.Split("   at");
                foreach (string item in first)
                {
                    if (item.Contains("cs:line"))
                    {
                        second = item.Split("cs:line ");
                        third = second[1];
                        sourceLine = "";
                        foreach (char itemInside in third)
                            if (Char.IsNumber(itemInside))
                                sourceLine += itemInside;
                    }
                }

                //Checking for the trace's souce line.
                if (string.IsNullOrWhiteSpace(sourceLine))
                    //Returning the assembled error response.
                    return new ErrorResponse(400, !string.IsNullOrWhiteSpace(exception.HelpLink) ? exception.HelpLink : exception.Message, className, methodName, null);
                else
                    //Returning the assembled error response.
                    return new ErrorResponse(400, !string.IsNullOrWhiteSpace(exception.HelpLink) ? exception.HelpLink : exception.Message, className, methodName, Convert.ToInt16(sourceLine));
            }
            catch
            {
                return new ErrorResponse(400, "It was not possible to be set a trace for the Exception.");
            }
        }
    }
}
