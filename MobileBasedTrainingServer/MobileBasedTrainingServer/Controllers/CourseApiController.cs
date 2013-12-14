using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MobileBasedTrainingServer.Models;
using MobileBasedTrainingServer.ViewModels;


namespace MobileBasedTrainingServer.Controllers
{
    public class CourseApiController : ApiController
    {
        private DataModelContainer db = new DataModelContainer();

        // GET api/CourseApi
		public object GetCourses()
        {
            return db.Courses.ToList()
				.Select(c => new 
				{
					id = c.Id,
					name = c.Name,
					description = c.Description,
					cluster = c.Cluster.Description,
                    href = String.Format("{0}/{1}", Request.RequestUri.AbsoluteUri, c.Id)
				});
        }

		// GET api/CourseApi/5
		public object GetCourse(int id)
		{
			Course course = db.Courses.Find(id);
			if (course == null)	
			{
				throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
			}
			
			var courseVideos = from courseVideo in db.CourseVideos
							   where courseVideo.CourseId == course.Id
							   select courseVideo.VideoId;
			var videos = from video in db.Videos
						 where courseVideos.Contains(video.Id)
						 select video;
			var results = new 
				{
					id = course.Id,
					name = course.Name,
					description = course.Description,
					cluster = course.Cluster.Description,
                    href = String.Format("{0}/{1}", Request.RequestUri.AbsoluteUri, course.Id), 
					videos = videos.Select(v => new { title = v.Title, description = v.Description, url = v.URL }).ToList()
				};
			return results;

		}

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}