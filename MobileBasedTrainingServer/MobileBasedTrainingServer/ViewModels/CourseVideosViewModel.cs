using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MobileBasedTrainingServer.Models;

namespace MobileBasedTrainingServer.ViewModels
{
	public class CourseVideosViewModel
	{
		public CourseVideosViewModel() { }
		
		public static CourseVideosViewModel FromCourses(IEnumerable<Course> courses)
		{
			CourseVideosViewModel cvvm = new CourseVideosViewModel();
			cvvm.Courses = courses.Select(c => CourseViewModel.FromCourse(c));
			return cvvm;
		}

		//Master list of courses and videos
		public IEnumerable<CourseViewModel> Courses { get; set; }
		public IEnumerable<VideoViewModel> Videos { get; set; }

		//Selected course details
		public CourseViewModel SelectedCourse { get; set; }
		public int SelectedCourseId { get; set; }
		public IEnumerable<VideoViewModel> SelectedCourseVideos { get; set; }
	}
}