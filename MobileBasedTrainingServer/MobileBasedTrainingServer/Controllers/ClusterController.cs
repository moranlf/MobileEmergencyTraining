using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using MobileBasedTrainingServer.Models;
using MobileBasedTrainingServer.ViewModels;

namespace MobileBasedTrainingServer.Controllers
{
    public class ClusterController : Controller
    {
        private DataModelContainer db = new DataModelContainer();

        //
        // GET: /Clister/

        public ActionResult Index()
        {
            return View(LoadClusters());
            
        }
        public JsonResult Clusters_Read()
        {
            return Json(LoadClusters(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Courses_Read(string cluster)
        {
            int clusterid;
            int.TryParse(cluster, out clusterid);
            return Json(LoadCourses(clusterid),JsonRequestBehavior.AllowGet);
        }
        public JsonResult Videos_Read(string course)
        {
            int courseid;
            if (int.TryParse(course, out courseid))
            {
                return Json(LoadVideos(courseid), JsonRequestBehavior.AllowGet);
            }
            return null;
        }

        private IEnumerable<ClusterViewModel> LoadClusters()
        {
            return from cluster in db.Clusters orderby cluster.Description
                   select new ClusterViewModel
                   {
                       Id = cluster.Id,
                       Description = cluster.Description
                   };
        }
        
        private IEnumerable<CourseViewModel> LoadCourses(int cluster)
        {
            return from course in db.Courses 
                   where course.Cluster.Id == cluster 
                   orderby course.Description
                   select new CourseViewModel
                   {
                       Id = course.Id,
                       Name = course.Name,
                       Description = course.Description,
                       Cluster = course.Cluster.Description,
                       ClusterId = course.Cluster.Id
                   };
        }

        private IEnumerable<VideoViewModel> LoadVideos(int courseid)
        {
            return from cv in db.CourseVideos
                where cv.CourseId == courseid
                orderby cv.Position
                select new VideoViewModel
                {
                    Id = cv.Video.Id,
                    Title = cv.Video.Title,
                    Description = cv.Video.Description,
                    Language = cv.Video.Language,
                    PublicationDate = cv.Video.PublicationDate,
                    PublisherEmail = cv.Video.PublisherEmail,
                    PublisherName = cv.Video.PublisherName,
                    Ratings = cv.Video.Ratings,
                    Tags = cv.Video.Tags,
                    URL = cv.Video.URL
                };
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}