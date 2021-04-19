namespace OriginFinancial.CodingChallenge.Service.Utils.Common
{
    public class SuccessResponse
    {
        /// <summary>
        /// The HTTP's return code.
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// The success message string.
        /// </summary>
        public string SuccessMessage { get; set; }

        /// <summary>
        /// The success response's constructor.
        /// </summary>
        /// <param name="code">The HTTP's return code.</param>
        /// <param name="successMessage">The success message string.</param>
        public SuccessResponse(int code, string successMessage)
        {
            Code = code;
            SuccessMessage = successMessage;
        }
    }
}
