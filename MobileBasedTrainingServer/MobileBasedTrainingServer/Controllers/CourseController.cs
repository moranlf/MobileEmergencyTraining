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
	public class CourseController : Controller
	{
		private readonly DataModelContainer db = new DataModelContainer();

		//
		// GET: /Course/

		public ActionResult Index()
		{
			return View(LoadCourses());
		}

		//
		// GET: /Course/Videos

		public ActionResult Videos(int? courseId = null)
		{
			var cvvm = CourseVideosViewModel.FromCourses(db.Courses.ToList());
			cvvm.Videos = db.Videos.ToList().Select(v => VideoViewModel.From(v));
			if (courseId != null)
			{
				var selectedCourse = db.Courses.Find(courseId);
				if (selectedCourse != null)
				{
					cvvm.SelectedCourseId = selectedCourse.Id;
					cvvm.SelectedCourse = CourseViewModel.FromCourse(selectedCourse);
					cvvm.SelectedCourseVideos = selectedCourse.CourseVideos.OrderBy(cv => cv.Position).Select(cv => VideoViewModel.From(cv.Video));
				}
			}
			return View(cvvm);
		}

		public ActionResult AddVideoToCourse(int courseId, int videoSelected)
		{
			if (!db.CourseVideos.Any(cv => cv.CourseId == courseId && cv.VideoId == videoSelected))
			{
				int position = 0;
				if (db.CourseVideos.Any(cv => cv.CourseId == courseId))
				{
					//Get max position
					position = db.CourseVideos.Where(cv => cv.CourseId == courseId).Max(cv => cv.Position);
				}
				var newCv = db.CourseVideos.Create();
				newCv.CourseId = courseId;
				newCv.VideoId = videoSelected;
				newCv.Position = ++position;
				db.CourseVideos.Add(newCv);
				db.SaveChanges();
			}
			return RedirectToAction("Videos", new { courseId = courseId });
		}

		public ActionResult RemoveVideoFromCourse(int courseId, int videoId)
		{
			var cv = db.CourseVideos.SingleOrDefault(c => c.CourseId == courseId && c.VideoId == videoId);
			if (cv != null)
			{
				db.CourseVideos.Remove(cv);
				db.SaveChanges();
			}
			return RedirectToAction("Videos", new { courseId = courseId });
		}

		public ActionResult Courses_Read([DataSourceRequest] DataSourceRequest request)
		{
			return Json(LoadCourses().ToDataSourceResult(request));
		}

		public ActionResult Clusters_Read()
		{
			return Json(LoadClusters(), JsonRequestBehavior.AllowGet);
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Courses_Create([DataSourceRequest]
                                           DataSourceRequest request, CourseViewModel viewModel)
		{
			if (viewModel != null && ModelState.IsValid)
			{
				var course = db.Courses.Create();
				course.Name = viewModel.Name;
				course.Description = viewModel.Description;
				course.Cluster = db.Clusters.Find(viewModel.ClusterId);
				viewModel.Cluster = course.Cluster.Description;
				db.Courses.Add(course);
				try
				{
					db.SaveChanges();
				}
				catch (Exception ex)
				{
					ModelState.AddModelError("", ex.Message);
				}
				viewModel.Id = course.Id;
			}

			return Json(new[] { viewModel }.ToDataSourceResult(request, ModelState));
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Courses_Update([DataSourceRequest]
                                           DataSourceRequest request, CourseViewModel viewModel)
		{
			if (viewModel != null && ModelState.IsValid)
			{
				var course = db.Courses.Find(viewModel.Id);
				if (course != null)
				{
					course.Name = viewModel.Name;
					course.Description = viewModel.Description;
					course.Cluster = db.Clusters.Find(viewModel.ClusterId);
					viewModel.Cluster = course.Cluster.Description;
					try
					{
						db.SaveChanges();
					}
					catch (Exception ex)
					{
						ModelState.AddModelError("", ex.Message);
					}
				}
			}

			return Json(new[] { viewModel }.ToDataSourceResult(request, ModelState));
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Courses_Destroy([DataSourceRequest]
                                            DataSourceRequest request, CourseViewModel viewModel)
		{
			if (viewModel != null)
			{
				Course course = db.Courses.Find(viewModel.Id);
				if (course != null)
				{
					db.Courses.Remove(course);
					try
					{
						db.SaveChanges();
					}
					catch (Exception ex)
					{
						ModelState.AddModelError("", ex.Message);
					}
				}
			}

			return Json(new[] { viewModel }.ToDataSourceResult(request, ModelState));
		}

		protected override void Dispose(bool disposing)
		{
			db.Dispose();
			base.Dispose(disposing);
		}

		private IEnumerable<CourseViewModel> LoadCourses()
		{
			return from course in db.Courses
				   select new CourseViewModel
				   {
					   Id = course.Id,
					   Name = course.Name,
					   Description = course.Description,
					   Cluster = course.Cluster.Description,
					   ClusterId = course.Cluster.Id
				   };
		}

		private IEnumerable<ClusterViewModel> LoadClusters()
		{
			var list =
				from cluster in db.Clusters
				orderby cluster.IsGeneral descending,
				cluster.Description
				select new ClusterViewModel
				{
					Id = cluster.Id,
					Description = cluster.Description
				};

			return list;
		}
	}
}