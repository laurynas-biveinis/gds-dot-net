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
    [CLSCompliant(false)]
    public class MediaFile : File
    {
        public int _width;
        public int _height;
        public int _bitRate;
        public int _dataRate;
        public int _channels;
        public string _comment;
        public Int64 _length;
        public DateTime _originalDate;
        public string _albumTitle;
        public string _artist;
        public string _genre;
        public string _lyrics;
        public int _trackNumber;
        public string _infoTip;
        public int _yearPublished;

        public MediaFile(Plugin plugin)
            : base(plugin, "Google.Desktop.MediaFile")
        {
        }

        protected MediaFile(Plugin plugin, string eventSchema)
            : base(plugin, eventSchema)
        {
        }

        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
                AddProperty("width", _width);
            }
        }

        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
                AddProperty("height", _height);
            }
        }

        public int BitRate
        {
            get
            {
                return _bitRate;
            }
            set
            {
                _bitRate = value;
                AddProperty("bit_rate", _bitRate);
            }
        }

        public int DataRate
        {
            get
            {
                return _dataRate;
            }
            set
            {
                _dataRate = value;
                AddProperty("data_rate", _dataRate);
            }
        }

        public int Channels
        {
            get
            {
                return _channels;
            }
            set
            {
                _channels = value;
                AddProperty("channels", _channels);
            }
        }

        public string Comment
        {
            get
            {
                return _comment;
            }
            set
            {
                _comment = value;
                AddProperty("comment", _comment);
            }
        }

        public Int64 Length
        {
            get
            {
                return _length;
            }
            set
            {
                _length = value;
                AddProperty("length", _length);
            }
        }

        public DateTime OriginalDate
        {
            get
            {
                return _originalDate;
            }
            set
            {
                _originalDate = value;
                AddProperty("original_date", _originalDate);
            }
        }

        public string AlbumTitle
        {
            get
            {
                return _albumTitle;
            }
            set
            {
                _albumTitle = value;
                AddProperty("album_title", _albumTitle);
            }
        }

        public string Artist
        {
            get
            {
                return _artist;
            }
            set
            {
                _artist = value;
                AddProperty("artist", _artist);
            }
        }

        public string Genre
        {
            get
            {
                return _genre;
            }
            set
            {
                _genre = value;
                AddProperty("genre", _genre);
            }
        }

        public string Lyrics
        {
            get
            {
                return _lyrics;
            }
            set
            {
                _lyrics = value;
                AddProperty("lyrics", _lyrics);
            }
        }

        public int TrackNumber
        {
            get
            {
                return _trackNumber;
            }
            set
            {
                _trackNumber = value;
                AddProperty("track_number", _trackNumber);
            }
        }

        public string InfoTip
        {
            get
            {
                return _infoTip;
            }
            set
            {
                _infoTip = value;
                AddProperty("info_tip", _infoTip);
            }
        }

        public int YearPublished
        {
            get
            {
                return _yearPublished;
            }
            set
            {
                _yearPublished = value;
                AddProperty("year_published", _yearPublished);
            }
        }

        protected override void AddRequiredProperties()
        {
            base.AddRequiredProperties();
        }
    }
}
