/*
·--------------------------------------------------------------------·
| C# Wrapper for Google Desktop Search Plugins                       |
| Copyright (c) 2005 Manas Tungare. http://www.manastungare.com/     |
| Copyright (c) 2009, 2010 gds-dot-net developers.                   |
| http://code.google.com/p/gds-dot-net/                              |
·--------------------------------------------------------------------·
| This library is free software; you can redistribute it and/or      |
| modify it under the terms of the GNU Lesser General Public         |
| License as published by the Free Software Foundation; either       |
| version 2.1 of the License, or (at your option) any later version. |
|                                                                    |
| This library is distributed in the hope that it will be useful,    |
| but WITHOUT ANY WARRANTY; without even the implied warranty of     |
| MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU  |
| Lesser General Public License for more details.                    |
|                                                                    |
| GNU LGPL: http://www.gnu.org/copyleft/lesser.html                  |
·--------------------------------------------------------------------·
*/


using System;
using System.Runtime.InteropServices;

namespace Org.ManasTungare.Google.Desktop
{
    /// <summary>
    /// A COMException thrown by the Interop framework will be translated to 
    /// a <code>GoogleDesktopException</code>, with error info available as 
    /// enums rather than OLE32 constants. 
    /// </summary>
    public class GoogleDesktopException : Exception
    {
        /// <summary>
        /// Enumeration of all error codes available from Google
        /// <see href="http://desktop.google.com/developerguide.html"/>
        /// </summary>
        public enum GoogleErrorCodes
        {
            E_EXTENSION_REGISTERED,
            E_COMPONENT_ALREADY_REGISTERED,
            E_COMPONENT_NOT_REGISTERED,
            E_COMPONENT_DISABLED, // from the Preferences page
            E_EVENT_TOO_LARGE,
            E_INVALID_EVENT_FLAGS,
            E_NO_SUCH_PROPERTY,
            E_NO_SUCH_SCHEMA,
            E_SERVICE_NOT_RUNNING,
            E_UNEXPECTED,
            S_INDEXING_PAUSED,
            E_COMPONENT_PROHIBITED,
            E_SEND_DELAYED,
            S_PROPERTY_TRUNCATED,
            E_PROPERTY_TOO_LARGE,
            E_PROPERTY_NOT_SET,
            E_SERVICE_IS_EXITING,
            E_APPLICATION_IS_EXITING,
            E_RETRY_SEND,
            E_SEND_TIMEOUT,
            E_REGISTRATION_CANCELLED_BY_USER,
            E_SEARCH_LOCKED,
            S_OK
        }

        /// <summary>
        /// Field to store error code after translation.
        /// </summary>
        private GoogleErrorCodes _err;

        /// <summary>
        /// Constructor to create a <code>GoogleDesktopException</code> from a <code>COMException</code>.
        /// Note that this is the only way a <code>GoogleDesktopException</code> may be instantiated.
        /// </summary>
        /// <param name="e">exception that was thrown by the COM Interop Assembly while executing a GoogleDesktop request.</param>
        public GoogleDesktopException(COMException e)
            : base(e.Message, e)
        {
            _err = GetErrorCode(e);
        }

        /// <summary>
        /// Read-only accessor for error code.
        /// </summary>
        public GoogleErrorCodes GoogleErrorCode
        {
            get
            {
                return _err;
            }
        }

        private enum HResultSuccessFlag
        {
            SEVERITY_SUCCESS = 0,
            SEVERITY_ERROR = 1
        }

        private enum HResultFacilityCode
        {
            FACILITY_ITF = 4
        }

        private static uint MakeHResult(HResultSuccessFlag successFlag, HResultFacilityCode facilityCode, ushort code)
        {
            return (((uint)successFlag) << 31) | (((uint)facilityCode) << 16) | ((uint)code);
        }

        private static readonly uint E_EXTENSION_REGISTERED = MakeHResult(HResultSuccessFlag.SEVERITY_ERROR, HResultFacilityCode.FACILITY_ITF, 0x0001);
        private static readonly uint E_COMPONENT_NOT_REGISTERED = MakeHResult(HResultSuccessFlag.SEVERITY_ERROR, HResultFacilityCode.FACILITY_ITF, 0x0002);
        private static readonly uint E_NO_SUCH_SCHEMA = MakeHResult(HResultSuccessFlag.SEVERITY_ERROR, HResultFacilityCode.FACILITY_ITF, 0x0003);
        private static readonly uint E_NO_SUCH_PROPERTY = MakeHResult(HResultSuccessFlag.SEVERITY_ERROR, HResultFacilityCode.FACILITY_ITF, 0x0004);
        private static readonly uint E_COMPONENT_DISABLED = MakeHResult(HResultSuccessFlag.SEVERITY_ERROR, HResultFacilityCode.FACILITY_ITF, 0x0005);
        private static readonly uint E_COMPONENT_ALREADY_REGISTERED = MakeHResult(HResultSuccessFlag.SEVERITY_ERROR, HResultFacilityCode.FACILITY_ITF, 0x0006);
        private static readonly uint S_INDEXING_PAUSED = MakeHResult(HResultSuccessFlag.SEVERITY_SUCCESS, HResultFacilityCode.FACILITY_ITF, 0x0007);
        private static readonly uint E_EVENT_TOO_LARGE = MakeHResult(HResultSuccessFlag.SEVERITY_ERROR, HResultFacilityCode.FACILITY_ITF, 0x0008);
        private static readonly uint E_SERVICE_NOT_RUNNING = MakeHResult(HResultSuccessFlag.SEVERITY_ERROR, HResultFacilityCode.FACILITY_ITF, 0x0009);
        private static readonly uint E_INVALID_EVENT_FLAGS = MakeHResult(HResultSuccessFlag.SEVERITY_ERROR, HResultFacilityCode.FACILITY_ITF, 0x000A);
        private static readonly uint E_COMPONENT_PROHIBITED = MakeHResult(HResultSuccessFlag.SEVERITY_ERROR, HResultFacilityCode.FACILITY_ITF, 0x000B);
        private static readonly uint E_SEND_DELAYED = MakeHResult(HResultSuccessFlag.SEVERITY_ERROR, HResultFacilityCode.FACILITY_ITF, 0x000C);
        private static readonly uint S_PROPERTY_TRUNCATED = MakeHResult(HResultSuccessFlag.SEVERITY_SUCCESS, HResultFacilityCode.FACILITY_ITF, 0x000D);
        private static readonly uint E_PROPERTY_TOO_LARGE = MakeHResult(HResultSuccessFlag.SEVERITY_ERROR, HResultFacilityCode.FACILITY_ITF, 0x000E);
        private static readonly uint E_PROPERTY_NOT_SET = MakeHResult(HResultSuccessFlag.SEVERITY_ERROR, HResultFacilityCode.FACILITY_ITF, 0x000F);
        private static readonly uint E_SERVICE_IS_EXITING = MakeHResult(HResultSuccessFlag.SEVERITY_ERROR, HResultFacilityCode.FACILITY_ITF, 0x0010);
        private static readonly uint E_APPLICATION_IS_EXITING = MakeHResult(HResultSuccessFlag.SEVERITY_ERROR, HResultFacilityCode.FACILITY_ITF, 0x0011);
        private static readonly uint E_RETRY_SEND = MakeHResult(HResultSuccessFlag.SEVERITY_ERROR, HResultFacilityCode.FACILITY_ITF, 0x0012);
        private static readonly uint E_SEND_TIMEOUT = MakeHResult(HResultSuccessFlag.SEVERITY_ERROR, HResultFacilityCode.FACILITY_ITF, 0x0013);
        private static readonly uint E_REGISTRATION_CANCELLED_BY_USER = MakeHResult(HResultSuccessFlag.SEVERITY_ERROR, HResultFacilityCode.FACILITY_ITF, 0x0014);
        private static readonly uint E_SEARCH_LOCKED = MakeHResult(HResultSuccessFlag.SEVERITY_ERROR, HResultFacilityCode.FACILITY_ITF, 0x0015);


        /// <summary>
        /// Helper method to translate from COM to .Net error codes.
        /// </summary>
        /// <param name="e">The <code>COMException</code> that is being wrapped by this exception.</param>
        /// <returns>Appropriately translated error code</returns>
        private static GoogleErrorCodes GetErrorCode(COMException e)
        {
            UInt32 errorCode = (UInt32)e.ErrorCode;
            if (errorCode == E_EXTENSION_REGISTERED) return GoogleErrorCodes.E_EXTENSION_REGISTERED;
            else if (errorCode == E_COMPONENT_NOT_REGISTERED) return GoogleErrorCodes.E_COMPONENT_NOT_REGISTERED;
            else if (errorCode == E_NO_SUCH_SCHEMA) return GoogleErrorCodes.E_NO_SUCH_SCHEMA;
            else if (errorCode == E_NO_SUCH_PROPERTY) return GoogleErrorCodes.E_NO_SUCH_PROPERTY;
            else if (errorCode == E_COMPONENT_DISABLED) return GoogleErrorCodes.E_COMPONENT_DISABLED;
            else if (errorCode == E_COMPONENT_ALREADY_REGISTERED) return GoogleErrorCodes.E_COMPONENT_ALREADY_REGISTERED;
            else if (errorCode == S_INDEXING_PAUSED) return GoogleErrorCodes.S_INDEXING_PAUSED;
            else if (errorCode == E_EVENT_TOO_LARGE) return GoogleErrorCodes.E_EVENT_TOO_LARGE;
            else if (errorCode == E_SERVICE_NOT_RUNNING) return GoogleErrorCodes.E_SERVICE_NOT_RUNNING;
            else if (errorCode == E_INVALID_EVENT_FLAGS) return GoogleErrorCodes.E_INVALID_EVENT_FLAGS;
            else if (errorCode == E_COMPONENT_PROHIBITED) return GoogleErrorCodes.E_COMPONENT_PROHIBITED;
            else if (errorCode == E_SEND_DELAYED) return GoogleErrorCodes.E_SEND_DELAYED;
            else if (errorCode == S_PROPERTY_TRUNCATED) return GoogleErrorCodes.S_PROPERTY_TRUNCATED;
            else if (errorCode == E_PROPERTY_TOO_LARGE) return GoogleErrorCodes.E_PROPERTY_TOO_LARGE;
            else if (errorCode == E_PROPERTY_NOT_SET) return GoogleErrorCodes.E_PROPERTY_NOT_SET;
            else if (errorCode == E_SERVICE_IS_EXITING) return GoogleErrorCodes.E_SERVICE_IS_EXITING;
            else if (errorCode == E_APPLICATION_IS_EXITING) return GoogleErrorCodes.E_APPLICATION_IS_EXITING;
            else if (errorCode == E_RETRY_SEND) return GoogleErrorCodes.E_RETRY_SEND;
            else if (errorCode == E_SEND_TIMEOUT) return GoogleErrorCodes.E_SEND_TIMEOUT;
            else if (errorCode == E_REGISTRATION_CANCELLED_BY_USER) return GoogleErrorCodes.E_REGISTRATION_CANCELLED_BY_USER;
            else if (errorCode == E_SEARCH_LOCKED) return GoogleErrorCodes.E_SEARCH_LOCKED;
            else return GoogleErrorCodes.E_UNEXPECTED;
        }

        /// <summary>
        /// A string representation of the exception.
        /// </summary>
        /// <returns>A string representation of the exception.</returns>
        public override string ToString()
        {
            return _err.ToString() + "\n" + base.ToString();
        }
    }
}
