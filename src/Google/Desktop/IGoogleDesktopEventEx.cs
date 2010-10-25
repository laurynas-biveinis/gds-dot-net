/*
·--------------------------------------------------------------------·
| C# Wrapper for Google Desktop Search Plugins                       |
| Copyright (c) 2010 gds-dot-net developers.                         |
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
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Org.ManasTungare.Google.Desktop
{
    /// <summary>
    /// C# interop wrapper for IGoogleDesktopEvent2 COM interface.  Provided because PreserveSig attribute 
    /// is needed for the SendEx method, otherwise we are unable to get retry_in_millisecs value on E_SEND_DELAYED.
    /// </summary>
    [ComImport, Guid("79EDFDE2-6BC6-41BD-A54C-F8AFF2F3789A"), InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface IGoogleDesktopEventEx
    {
        // IGoogleDesktopEvent members
        void AddProperty([In, MarshalAs(UnmanagedType.BStr)] string property_name, 
                         [In, MarshalAs(UnmanagedType.Struct)] object property_value);

        void Send([In] int event_flags);

        // IGoogleDesktopEvent2 members
        [PreserveSig]
        int SendEx([In] int event_flags, [Out] out int retry_in_millisec);
    }
}
