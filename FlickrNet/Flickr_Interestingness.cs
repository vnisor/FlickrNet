﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FlickrNet
{
    public partial class Flickr
    {
        /// <summary>
        /// Gets a list of photos from the most recent interstingness list.
        /// </summary>
        /// <param name="perPage">Number of photos per page.</param>
        /// <param name="page">The page number to return.</param>
        /// <param name="extras"><see cref="PhotoSearchExtras"/> enumeration.</param>
        /// <returns><see cref="Photos"/> instance containing list of photos.</returns>
        public Photos InterestingnessGetList(PhotoSearchExtras extras, int page, int perPage)
        {
            return InterestingnessGetList(DateTime.MinValue, extras, page, perPage);
        }

        /// <summary>
        /// Gets a list of photos from the interstingness list for the specified date.
        /// </summary>
        /// <param name="date">The date to return the interestingness list for.</param>
        /// <returns><see cref="Photos"/> instance containing list of photos.</returns>
        public Photos InterestingnessGetList(DateTime date)
        {
            return InterestingnessGetList(date, PhotoSearchExtras.All, 0, 0);
        }

        /// <summary>
        /// Gets a list of photos from the most recent interstingness list.
        /// </summary>
        /// <returns><see cref="Photos"/> instance containing list of photos.</returns>
        public Photos InterestingnessGetList()
        {
            return InterestingnessGetList(DateTime.MinValue, PhotoSearchExtras.All, 0, 0);
        }

        /// <summary>
        /// Gets a list of photos from the most recent interstingness list.
        /// </summary>
        /// <param name="date">The date to return the interestingness photos for.</param>
        /// <param name="extras">The extra parameters to return along with the search results.
        /// See <see cref="PhotoSearchOptions"/> for more details.</param>
        /// <param name="perPage">The number of results to return per page.</param>
        /// <param name="page">The page of the results to return.</param>
        /// <returns></returns>
        public Photos InterestingnessGetList(DateTime date, PhotoSearchExtras extras, int page, int perPage)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("method", "flickr.interestingness.getList");

            if (date > DateTime.MinValue) parameters.Add("date", date.ToString("yyyy-MM-dd"));
            if (perPage > 0) parameters.Add("per_page", perPage.ToString());
            if (page > 0) parameters.Add("page", page.ToString());
            if (extras != PhotoSearchExtras.None)
                parameters.Add("extras", Utils.ExtrasToString(extras));

            return GetResponseCache<Photos>(parameters);
        }
    }
}
