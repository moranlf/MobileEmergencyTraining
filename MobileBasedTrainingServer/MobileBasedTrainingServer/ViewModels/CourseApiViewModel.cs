using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MobileBasedTrainingServer.Models;

namespace MobileBasedTrainingServer.ViewModels
{
    public class CourseApiViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string cluster { get; set; }

	
		public static CourseApiViewModel From(Course course)
		{
			CourseApiViewModel result = new CourseApiViewModel();
			result.id = course.Id;
			result.name = course.Name;
			result.description = course.Description;
			result.cluster = course.Cluster.Description;
			return result;
		}
    }
}