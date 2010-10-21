/*
·--------------------------------------------------------------------·
| C# Wrapper for Google Desktop Search Plugins                       |
| Copyright (c) 2005, Manas Tungare. http://www.manastungare.com/    |
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

using GoogleDesktopAPILib;
using System;
using System.Runtime.InteropServices;


namespace Org.ManasTungare.Google.Desktop
{
    public class Plugin
    {
        private const string IndexingRegistrarID = "GoogleDesktop.IndexingRegistration";

        readonly string _name = "";
        readonly string _description = "";
        readonly string _componentGuid = "";
        readonly string _icon = "";

        public Plugin(string name, string description, string componentGuid, string icon)
        {
            _name = name;
            _description = description;
            _componentGuid = componentGuid;
            _icon = icon;
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
        }

        public string ComponentGUID
        {
            get
            {
                return _componentGuid;
            }
        }

        public string Icon
        {
            get
            {
                return _icon;
            }
        }

        public void Register()
        {
            DoRegistration(true);
        }

        public void Unregister()
        {
            DoRegistration(false);
        }

        private void DoRegistration(bool install)
        {
            try
            {
                // register/unregister the component
                GoogleDesktopRegistrar gdsReg = new GoogleDesktopRegistrar();

                if (install)
                {
                    // register with GDS
                    object[] componentDesc = new object[6] {
                                                      "Title", _name, 
                                                      "Description", _description, 
                                                      "Icon", _icon
                                                    };
                    gdsReg.StartComponentRegistration(_componentGuid, componentDesc);
                    IGoogleDesktopRegisterIndexingPlugin indexReg 
                        = (IGoogleDesktopRegisterIndexingPlugin)gdsReg.GetRegistrationInterface(IndexingRegistrarID);
                    indexReg.RegisterIndexingPlugin(null);
                    gdsReg.FinishComponentRegistration();
                }
                else
                {
                    gdsReg.UnregisterComponent(_componentGuid);
                }
            }
            catch (COMException e)
            {
                throw new GoogleDesktopException(e);
            }
        }
    }
}
