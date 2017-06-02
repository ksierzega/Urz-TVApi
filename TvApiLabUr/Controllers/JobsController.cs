﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TvApiLabUr.Services;

namespace TvApiLabUr.Controllers
{
    public class JobsController : ApiController
    {
        [HttpPost, Route("jobs/execute")]
        public async Task<IHttpActionResult> ExecuteJobs()
        {
            var traktTvService = new TraktTvService();
            await traktTvService.DownloadMovies();

            return Ok();
        }
    }
}
