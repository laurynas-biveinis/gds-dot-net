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

namespace Org.ManasTungare.Google.Desktop.Schemas{
  public class Email : Indexable {

    private string _mailHeader;
    private string _subject;
    private string _from;
    private string _to;
    private string _cc;
    private string _bcc;
    private string _replyTo;
    private DateTime _received; 
    private string _folderName;

    public Email(Plugin plugin) : base(plugin, "Google.Desktop.Email") {
      // Nothing
    }

    protected Email(Plugin plugin, string eventSchema) : base(plugin, eventSchema) {
      // Nothing
    }

    public string MailHeader {
      get {
        return _mailHeader;
      }
      set {
        _mailHeader = value;
        AddProperty("mail_header", _mailHeader);
      }
    }

    public string Subject {
      get {
        return _subject;
      }
      set {
        _subject = value;
        AddProperty("subject", _subject);
      }
    }

    public string From {
      get {
        return _from;
      }
      set {
        _from = value;
        AddProperty("from", _from);
      }
    }

    public string To {
      get {
        return _to;
      }
      set {
        _to = value;
        AddProperty("to", _to);
      }
    }

    public string Cc {
      get {
        return _cc;
      }
      set {
        _cc = value;
        AddProperty("cc", _cc);
      }
    }

    public string Bcc {
      get {
        return _bcc;
      }
      set {
        _bcc = value;
        AddProperty("bcc", _bcc);
      }
    }

    public string ReplyTo {
      get {
        return _replyTo;
      }
      set {
        _replyTo = value;
        AddProperty("replyto", _replyTo);
      }
    }

    public DateTime Received {
      get {
        return _received;
      }
      set {
        _received = value;
        // Required Property
      }
    }

    public string FolderName {
      get {
        return _folderName;
      }
      set {
        _folderName = value;
        AddProperty("folder_name", _folderName);
      }
    }

    protected override void AddRequiredProperties() {
      base.AddRequiredProperties();
      AddProperty("received", _received);
    }
  }
}
