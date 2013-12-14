using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MobileBasedTrainingServer.Models;
using System.Collections.Generic;
using MobileBasedTrainingServer.ViewModels;

namespace MobileBasedTrainingServer.Controllers
{
    public class VideosApiController : ApiController
    {
		private DataModelContainer db = new DataModelContainer();

		// GET api/videos
        public object Get()
        {
			var videos = db.Videos.Select(v => new { title = v.Title, description = v.Description }).ToList();
			return videos.AsEnumerable();
        }

        // GET api/videos/5
		public VideoViewModel Get(int id)
        {
			var video = db.Videos.Find(id);
			if( video == null)
			{
				throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
			}
			return VideoViewModel.From(video);
		}

    }
}
