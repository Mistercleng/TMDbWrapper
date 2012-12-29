﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TmdbWrapper.Utilities;
using Windows.Data.Json;

namespace TmdbWrapper.Movies
{
    /// <summary>
    /// Collection of trailers for a movie
    /// </summary>
    public class Trailers : ITmdbObject
    {
        /// <summary>
        /// Id of the movie.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// List of trailers hosted by quicktime.
        /// </summary>
        public IList<Trailer> QuickTime { get; set; }
        /// <summary>
        /// List of trailers hoster by youtube.
        /// </summary>
        public IList<Trailer> Youtube { get; set; } 

        void ITmdbObject.ProcessJson(JsonObject jsonObject)
        {
            Id = (int)jsonObject.GetNamedValue("id").GetSafeNumber();
            JsonValue quickTimeValueObject = jsonObject.GetNamedValue("quicktime");
            QuickTime = quickTimeValueObject.ProcessArray<Trailer>();
            JsonValue youtubeValueObject = jsonObject.GetNamedValue("youtube");
            Youtube = youtubeValueObject.ProcessArray<Trailer>();
        }
    }
}