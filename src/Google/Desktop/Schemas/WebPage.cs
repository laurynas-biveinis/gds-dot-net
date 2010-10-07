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

using System;

namespace Org.ManasTungare.Google.Desktop.Schemas
{
    public class WebPage : File
    {
        private bool _bookmarked;
        private DateTime _interactionPeriod;

        public WebPage(Plugin plugin)
            : base(plugin, "Google.Desktop.WebPage")
        {
        }

        protected WebPage(Plugin plugin, string eventSchema)
            : base(plugin, eventSchema)
        {
        }

        public bool Bookmarked
        {
            get
            {
                return _bookmarked;
            }
            set
            {
                _bookmarked = value;
                AddProperty("bookmarked", _bookmarked);
            }
        }

        public DateTime InteractionPeriod
        {
            get
            {
                return _interactionPeriod;
            }
            set
            {
                _interactionPeriod = value;
                AddProperty("interaction_period", _interactionPeriod);
            }
        }
    }
}
