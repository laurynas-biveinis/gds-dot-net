/*
·--------------------------------------------------------------------·
| C# Wrapper for Google Desktop Search Plugins                       |
| Copyright (c) 2005, Manas Tungare. http://www.manastungare.com/    |
| Copyright (c) 2009, gds-dot-net developers                         |
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
| Lesser General Public License for more details.                    |                                               \\
|                                                                    |
| GNU LGPL: http://www.gnu.org/copyleft/lesser.html                  |
·--------------------------------------------------------------------·
*/

using System;
using System.Runtime.InteropServices;
using Interop.GoogleDesktopAPI2;

namespace Org.ManasTungare.Google.Desktop.Schemas{
  public abstract class Indexable {

    public enum EventFlags {
      None,
      Historical,
    }

    public enum ContentTypes {
      TextPlain,
      TextHTML
    }

    public enum ThumbnailFormats {
      ImagePng,
      ImageJpeg,
      ImageGif
    }

    protected const int EventFlagIndexable   = 0x00000001;
    protected const int EventFlagHistorical  = 0x00000010;
    protected const UInt32 E_COMPONENT_NOT_REGISTERED = 0x80040002;

    protected string _eventSchema = "Google.Desktop.Indexable";
    protected IGoogleDesktopSearchEvent _gdsEvent;
    protected Plugin _plugin; // that created us

    // Set to null to detect if properties were set or not.
    protected string _content = null;
    protected ContentTypes _contentType = 0;
    protected Int64 _nativeSize = 0;
    protected byte[] _thumbnail = null;
    protected ThumbnailFormats _thumbnailFormat = 0;

    internal Indexable(Plugin plugin, string eventSchema) {
      _plugin = plugin;
      _eventSchema = eventSchema;


      // Create an instance of Google's COM object ...
      GoogleDesktopSearchClass gdsClass = new GoogleDesktopSearchClass();
      object gdsEventDisp = null;
      try {
        gdsEventDisp = gdsClass.CreateEvent(_plugin.ComponentGUID, _eventSchema);
      }
      catch(COMException e) {
        if (E_COMPONENT_NOT_REGISTERED == (UInt32)e.ErrorCode) {
          _plugin.Register();
          // Retry
          try {
            gdsEventDisp = gdsClass.CreateEvent(_plugin.ComponentGUID, _eventSchema);
          }
          catch (COMException e2) {
            throw new GoogleDesktopException(e2);
          }
        }
      }
      _gdsEvent = (IGoogleDesktopSearchEvent)gdsEventDisp;
    }

    public string Content {
      get {
        return _content;
      }
      set {
        _content = value;
      }
    }

    public ContentTypes ContentType {
      get {
        return _contentType;
      }
      set {
        _contentType = value;
      }
    }

    public Int64 NativeSize {
      get {
        return _nativeSize;
      }
      set {
        _nativeSize = value;
      }
    }

    public byte[] Thumbnail {
      get {
        return _thumbnail;
      }
      set {
        _thumbnail = value;
      }
    }

    public ThumbnailFormats ThumbnailFormat {
      get {
        return _thumbnailFormat;
      }
      set {
        _thumbnailFormat = value;
      }
    }

    protected virtual void AddProperty(string name, object val) {
      if (null == name) {
        throw new PropertyNotSetException();
      }
      if (null == val) {
        throw new PropertyNotSetException(name);
      }

      if (val is System.DateTime) {
        // Convert dates to OLE Automation compatible types.
        _gdsEvent.AddProperty(name, ((System.DateTime)val).ToOADate() );
      }
      else if (val is ContentTypes) {
        if (ContentTypes.TextHTML == (ContentTypes) val) {
          _gdsEvent.AddProperty(name, "text/html" );
        }
        else if (ContentTypes.TextPlain == (ContentTypes) val) {
          _gdsEvent.AddProperty(name, "text/plain" );
        }
      }
      else if (val is ThumbnailFormats) {
        if (ThumbnailFormats.ImageGif == (ThumbnailFormats) val) {
          _gdsEvent.AddProperty(name, "image/gif" );
        }
        else if (ThumbnailFormats.ImageJpeg == (ThumbnailFormats) val) {
          _gdsEvent.AddProperty(name, "image/jpeg" );
        }
         else if (ThumbnailFormats.ImagePng == (ThumbnailFormats) val) {
            _gdsEvent.AddProperty(name, "image/png" );
        }
      }
      else { 
        // No other types require special conversion: Int16, Int32, Int64, String.
        _gdsEvent.AddProperty(name, val );
      }
    }

    protected virtual void AddRequiredProperties() {
      // If overriding, add your own properties before calling base.Send();
      AddProperty("content", _content);
      AddProperty("format", _contentType);
    }

    public void Send(EventFlags eventFlags) {
      AddRequiredProperties();

      try {
        if (EventFlags.Historical == eventFlags) {
          _gdsEvent.Send(EventFlagHistorical | EventFlagIndexable);
        }
        else {
          _gdsEvent.Send(EventFlagIndexable);
        }
      }
      catch (COMException e) {
        throw new GoogleDesktopException(e);
      }
    }
  }
}
