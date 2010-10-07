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
    public class IM : Indexable
    {

        private int _conversationId;
        private DateTime _messageTime;
        private string _title;
        private string _userName;
        private string _buddyName;


        public IM(Plugin plugin)
            : base(plugin, "Google.Desktop.IM")
        {
        }

        protected IM(Plugin plugin, string eventSchema)
            : base(plugin, eventSchema)
        {
        }

        public int ConversationID
        {
            get
            {
                return _conversationId;
            }
            set
            {
                _conversationId = value;
                AddProperty("conversation_id", _conversationId);
            }
        }

        public DateTime MessageTime
        {
            get
            {
                return _messageTime;
            }
            set
            {
                _messageTime = value;
                // Required Property
            }
        }

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                AddProperty("title", _title);
            }
        }

        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                AddProperty("user_name", _userName);
            }
        }

        public string BuddyName
        {
            get
            {
                return _buddyName;
            }
            set
            {
                _buddyName = value;
                // Required Property
            }
        }

        protected override void AddRequiredProperties()
        {
            base.AddRequiredProperties();
            AddProperty("message_time", _messageTime);
            AddProperty("buddy_name", _buddyName);
        }
    }
}
