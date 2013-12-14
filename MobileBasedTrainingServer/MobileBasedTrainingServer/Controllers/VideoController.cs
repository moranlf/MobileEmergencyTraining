using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using MobileBasedTrainingServer.Models;
using MobileBasedTrainingServer.ViewModels;

namespace MobileBasedTrainingServer.Controllers
{
	public class VideoController : Controller
	{
		private DataModelContainer db = new DataModelContainer();

		public ActionResult Index()
		{
			return View(db.Videos.ToList().Select(v => VideoViewModel.From(v)));
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult EditingInline_Create([DataSourceRequest] DataSourceRequest request, VideoViewModel video)
		{
			if (video != null && ModelState.IsValid)
			{
				Video modelVideo = video.ToVideo();
				db.Videos.Add(modelVideo);
				try
				{
					db.SaveChanges();
				}
				catch (Exception ex)
				{
					ModelState.AddModelError("", ex.Message);
				}
				return Json(new[] { VideoViewModel.From(modelVideo) }.ToDataSourceResult(request, ModelState));
			}
			// This has to get fixed to display a fail.
			return Json(new[] {video}.ToDataSourceResult(request, ModelState)); ;
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Update([DataSourceRequest] DataSourceRequest request, VideoViewModel video)
		{
			if (video != null && ModelState.IsValid)
			{
				Video modelVideo = video.ToVideo();
				db.Entry(modelVideo).State = EntityState.Modified;
				try
				{
					db.SaveChanges();
				}
				catch (Exception ex)
				{
					ModelState.AddModelError("", ex.Message);
				}
				return Json(new[] { VideoViewModel.From(modelVideo) }.ToDataSourceResult(request, ModelState));
			}
			return Json(new[] { video }.ToDataSourceResult(request, ModelState));
		}

		[AcceptVerbs(HttpVerbs.Post)]
		public ActionResult Delete([DataSourceRequest] DataSourceRequest request, VideoViewModel video)
		{
			if (video != null)
			{
				Video videoToDelete = db.Videos.Find(video.Id);
				if (videoToDelete != null)
				{
					db.Videos.Remove(videoToDelete);
					try
					{
						db.SaveChanges();
					}
					catch (Exception ex)
					{
						ModelState.AddModelError("", ex.Message);
					}
					return Json(new[] { VideoViewModel.From(videoToDelete) }.ToDataSourceResult(request, ModelState));
				}
			}
			return Json(new[] { video }.ToDataSourceResult(request, ModelState));
		}

		protected override void Dispose(bool disposing)
		{
			db.Dispose();
			base.Dispose(disposing);
		}
	}
}