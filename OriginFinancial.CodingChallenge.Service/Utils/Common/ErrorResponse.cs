using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OriginFinancial.CodingChallenge.Service.Utils.Common
{
    public class ErrorResponse
    {
        /// <summary>
        /// The error response constructor.
        /// </summary>
        /// <param name="code">The HTTP's return code.</param>
        /// <param name="errorMessage">The possible error messages.</param>
        /// <param name="className">The possible class where the error took place.</param>
        /// <param name="methodName">The possible method in which the error took place.</param>
        /// <param name="line">The possible line at which the error took place.</param>
        public ErrorResponse(int code, string errorMessage = "", string className = null, string methodName = null, int? line = null)
        {
            //Setting the http's error's code.
            Code = code;

            //Setting the error's timestamp.
            Date = $"{DateTime.Now.Ticks} - {DateTime.Now.ToString("dd/MM/yyyy - HH:mm:ss")}";

            //Checking/setting the error messages.
            if (!string.IsNullOrWhiteSpace(errorMessage))
            {
                //Starting error field's list.
                Errors = new List<ErrorFields>();

                //Checking for multiple error messages.
                if (errorMessage.Contains('|'))
                {
                    //Creating the array of error messages.
                    string[] arrErrorMessages = errorMessage.Split('|');

                    //Sweeping through the error messages.
                    foreach (string error in arrErrorMessages)
                    {
                        Errors.Add(new ErrorFields
                        {
                            ErrorMessage = error,
                            ClassName = className,
                            MethodName = methodName,
                            Line = line
                        });
                    }
                }
                else
                {
                    Errors.Add(new ErrorFields
                    {
                        ErrorMessage = errorMessage,
                        ClassName = className,
                        MethodName = methodName,
                        Line = line
                    });
                }
            }
        }

        /// <summary>
        /// The HTTP's method return code.
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// The date for the error's occurring.
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// The possible errors' fields.
        /// </summary>
        public List<ErrorFields> Errors { get; set; }

        public class ErrorFields
        {
            /// <summary>
            /// The error message from the exception or business rule.
            /// </summary>
            public string ErrorMessage { get; set; } = null;

            /// <summary>
            /// The error's class of origin.
            /// </summary>
            public string ClassName { get; set; } = null;

            /// <summary>
            /// The method where the error took place.
            /// </summary>
            public string MethodName { get; set; } = null;

            /// <summary>
            /// The line of code where the error took place.
            /// </summary>
            public int? Line { get; set; } = null;
        }
    }
}
