﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FlickrNet
{
    /// <summary>
    /// Information about a video, as returned by <see cref="PhotoInfo.VideoInfo"/>.
    /// </summary>
    public sealed class VideoInfo : IFlickrParsable
    {
        /// <summary>
        /// True or false if the video is ready to be displayed.
        /// </summary>
        public bool Ready { get; private set; }
        /// <summary>
        /// True or false depending on if processing of the video succeeded or not.
        /// </summary>
        public bool Failed { get; private set; }
        /// <summary>
        /// True or false depending on if the processing of the video is pending or not.
        /// </summary>
        public bool Pending { get; private set; }
        /// <summary>
        /// The duration of the video, in seconds.
        /// </summary>
        public int Duration { get; private set; }
        /// <summary>
        /// The width of the video.
        /// </summary>
        public int Width { get; private set; }
        /// <summary>
        /// The height of the video.
        /// </summary>
        public int Height { get; private set; }

        void IFlickrParsable.Load(System.Xml.XmlReader reader)
        {
            while (reader.MoveToNextAttribute())
            {
                switch (reader.LocalName)
                {
                    case "ready":
                        Ready = (reader.Value == "1");
                        break;
                    case "failed":
                        Failed = (reader.Value == "1");
                        break;
                    case "pending":
                        Pending = (reader.Value == "1");
                        break;
                    case "duration":
                        Duration = reader.ReadContentAsInt();
                        break;
                    case "width":
                        Width = reader.ReadContentAsInt();
                        break;
                    case "height":
                        Height = reader.ReadContentAsInt();
                        break;
                    default:
                        UtilityMethods.CheckParsingException(reader);
                        break;
                }
            }

            reader.Read();
        }
    }
}
