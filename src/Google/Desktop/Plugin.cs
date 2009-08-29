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
using Interop.GoogleDesktopAPI2;
using System.Runtime.InteropServices;


namespace Org.ManasTungare.Google.Desktop {
  public class Plugin {
    private const UInt32 E_COMPONENT_NOT_REGISTERED = 0x80040002;
    private const UInt32 E_COMPONENT_ALREADY_REGISTERED = 0x80040006;

    string _name = "";
    string _description = "";
    string _componentGuid = "";
    string _icon = "";

    public Plugin(string name, string description, string componentGuid) {
      _name = name;
      _description = description;
      _componentGuid = componentGuid;
      _icon = "no icon";
    }

    public string Name {
      get {
        return _name;
      }
    }

    public string Description {
      get {
        return _description;
      }
    }

    public string ComponentGUID {
      get {
        return _componentGuid;
      }
    }

    public string Icon {
      get {
        return _icon;
      }
      set {
        _icon = value;
      }
    }

    public bool Register() {
      return DoRegistration(true);
    }

    public bool Unregister() {
      return DoRegistration(false);
    }

    // The DoRegistration(...) method was copied from sample code provided by Google, Inc.
    private bool DoRegistration(bool install) {
      try {
        // register/unregister the component
        GoogleDesktopSearchRegisterClass gdsReg = new GoogleDesktopSearchRegisterClass();

        if (install) {
          try {
            // register with GDS
            object [] componentDesc = new object[6] {
                                                      "Title", _name, 
                                                      "Description", _description, 
                                                      "Icon", "no icon"
                                                    };
            gdsReg.RegisterComponent(_componentGuid, componentDesc);
          }
          catch(COMException e) {
            // check if not already registered
            if ((UInt32)e.ErrorCode != E_COMPONENT_ALREADY_REGISTERED) { // E_COMPONENT_ALREADY_REGISTERED
              return false;
            }
          }
        }
        else {
          try {
            gdsReg.UnregisterComponent(_componentGuid);
          }
          catch(COMException e) {
            // check if not already unregistered
            if ((UInt32)e.ErrorCode != E_COMPONENT_NOT_REGISTERED) { // 
              throw new GoogleDesktopException(e);
            }
          }
        }
      }
      catch (COMException e) {
        throw new GoogleDesktopException(e);
      }
      return true;
    }
  }
}
