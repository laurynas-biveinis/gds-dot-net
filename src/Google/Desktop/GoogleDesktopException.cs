/*
·--------------------------------------------------------------------·
| C# Wrapper for Google Desktop Search Plugins                       |
| Copyright (c) 2005, Manas Tungare. http://www.manastungare.com/    |
·--------------------------------------------------------------------·
| This library is free software; you can redistribute it and/or      |
| modify it under the terms of the GNU Lesser General Public         |
| License as published by the Free Software Foundation; either       |
| version 2.1 of the License, or (at your option) any later version. |
|                                                                    |
| This library is distributed in the hope that it will be useful,    |
| but WITHOUT ANY WARRANTY; without even the implied warranty of     |
| MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU  |
| Lesser General Public License for more details.                    |                                               \\
|                                                                    |
| GNU LGPL: http://www.gnu.org/copyleft/lesser.html                  |
·--------------------------------------------------------------------·
*/


using System;
using System.Runtime.InteropServices;

namespace Org.ManasTungare.Google.Desktop {
  /// <summary>
  /// A COMException thrown by the Interop framework will be translated to 
  /// a <code>GoogleDesktopException</code>, with error info available as 
  /// enums rather than OLE32 constants. 
  /// </summary>
  public class GoogleDesktopException : Exception {
    /// <summary>
    /// Enumeration of all error codes available from Google
    /// <see href="http://desktop.google.com/developerguide.html"/>
    /// </summary>
    public enum GoogleErrorCodes {
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
    public GoogleDesktopException (COMException e) : base(e.Message, e) {
      _err = GetErrorCode(e);
    }

    /// <summary>
    /// Read-only accessor for error code.
    /// </summary>
    public GoogleErrorCodes GoogleErrorCode {
      get {
        return _err;
      }
    }

    /// <summary>
    /// Helper method to translate from COM to .Net error codes.
    /// </summary>
    /// <param name="e">The <code>COMException</code> that is being wrapped by this exception.</param>
    /// <returns>Appropriately translated error code</returns>
    private static GoogleErrorCodes GetErrorCode(COMException e) {
      UInt32 errorCode = (UInt32)e.ErrorCode;
      switch (errorCode) {
        case 0x80040001:
          return GoogleErrorCodes.E_EXTENSION_REGISTERED;
          break;
        case 0x80040002:
          return GoogleErrorCodes.E_COMPONENT_NOT_REGISTERED;
          break;
        case 0x80040003:
          return GoogleErrorCodes.E_NO_SUCH_SCHEMA;
          break;
        case 0x80040004:
          return GoogleErrorCodes.E_NO_SUCH_PROPERTY;
          break;
        case 0x80040005:
          return GoogleErrorCodes.E_COMPONENT_DISABLED;
          break;
        case 0x80040006:
          return GoogleErrorCodes.E_COMPONENT_ALREADY_REGISTERED;
          break;
        case 0x80040007:
          return GoogleErrorCodes.S_INDEXING_PAUSED;
          break;
        case 0x80040008:
          return GoogleErrorCodes.E_EVENT_TOO_LARGE;
          break;
        case 0x80040009:
          return GoogleErrorCodes.E_SERVICE_NOT_RUNNING;
          break;
        case 0x8004000A:
          return GoogleErrorCodes.E_INVALID_EVENT_FLAGS;
          break;
        default:
          return GoogleErrorCodes.E_UNEXPECTED;
          break;
      }
    }

    /// <summary>
    /// A string representation of the exception.
    /// </summary>
    /// <returns>A string representation of the exception.</returns>
    public override string ToString() {
      return _err.ToString() + "\n" + base.ToString();
    }
  }
}
