﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TmdbWrapper.Movies;
using TmdbWrapper.Search;
using TmdbWrapper.Utilities;

namespace TmdbWrapper
{
    public static partial class TheMovieDatabase
    {
        /// <summary>
        /// Searches for movies that match the query string.
        /// </summary>
        /// <param name="query">The query string</param>
        /// <param name="page">The page of the results</param>
        /// <param name="includeAdult">Indicates whether to include adult movies.</param>
        /// <param name="year">If specified the year the movies are released.</param>
        /// <returns>A search result set of movie summaries.</returns>
        public static async Task<SearchResultBase<MovieSummary>> SearchMovie(string query, int page = 1, bool? includeAdult = null, int? year = null)
        {
            Request request = new Request("search/movie");
            
            request.AddParameter("query", query.EscapeString());
            request.AddParameter("page", page);
            if (!string.IsNullOrEmpty(Language))
                request.AddParameter("language", Language);
            if (includeAdult.HasValue)
                request.AddParameter("include_adult", includeAdult.Value ? "true" : "false");
            if (year.HasValue)
                request.AddParameter("year", year.Value.ToString());

            return await request.ProcessSearchRequestAsync<MovieSummary>();
        }

        /// <summary>
        /// Searches for collections that match the query string.
        /// </summary>
        /// <param name="query">The query string</param>
        /// <param name="page">The page of the search result set.</param>
        /// <returns>The resultset with found collections.</returns>
        public static async Task<SearchResultBase<CollectionSummary>> SearchCollection(string query, int page = 1)
        {
            Request request = new Request("search/collection");
            request.AddParameter("query", query.EscapeString());
            request.AddParameter("page", page);
            if (!string.IsNullOrEmpty(Language))
                request.AddParameter("language", Language);
            return await request.ProcessSearchRequestAsync<CollectionSummary>();
        }

        /// <summary>
        /// Searches for persons that match the query string.
        /// </summary>
        /// <param name="query">The query string</param>
        /// <param name="page">The page of the search result set.</param>
        /// <returns>The resultset with the found person summaries.</returns>
        public static async Task<SearchResultBase<PersonSummary>> SearchPerson(string query, int page = 1)
        {
            Request request = new Request("search/person");
            
            request.AddParameter("query", query.EscapeString());
            request.AddParameter("page", page);
            if (!string.IsNullOrEmpty(Language))
                request.AddParameter("language", Language);

            return await request.ProcessSearchRequestAsync<PersonSummary>();
        }

        /// <summary>
        /// Searches for companies that match the query string.
        /// </summary>
        /// <param name="query">The query string.</param>
        /// <param name="page">The page of the search result set.</param>
        /// <returns>The resultset with the found company summaries.</returns>
        public static async Task<SearchResultBase<CompanySummary>> SearchCompany(string query, int page = 1)
        {
            Request request = new Request("search/company");
            request.AddParameter("query", query.EscapeString());
            request.AddParameter("page", page);
            return await request.ProcessSearchRequestAsync<CompanySummary>();
        }              
    }
}