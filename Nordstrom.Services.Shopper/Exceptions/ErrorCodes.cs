using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nordstrom.Services.Shopper.Exceptions
{
    /// <summary>
    /// Used to map error codes in groups that can correlate to Http Status Codes
    /// </summary>
    public class ErrorCodes
    {
        public ErrorCodes()
        { }

        /// <summary>
        /// Used to signify an unexpected exception in the service
        /// </summary>
        public static uint UnexpectedError { get { return 0; } }

        #region BadRequest (400) Errors
        /// <summary>
        /// Used when trying to add an item to the cart that already exists
        /// </summary>
        public static uint InvalidVersionHeader { get { return 1002; } }

        /// <summary>
        /// Used when trying to add an item to the cart that already exists
        /// </summary>
        public static uint InvalidShopperId { get { return 1003; } }

        #endregion

        #region UnAuthorized (403) Errors
        #endregion

        #region Not Found (404) Errors
        #endregion
    }
}