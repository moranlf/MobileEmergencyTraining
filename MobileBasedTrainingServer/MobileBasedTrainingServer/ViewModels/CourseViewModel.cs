using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MobileBasedTrainingServer.Models;

namespace MobileBasedTrainingServer.ViewModels
{
    public class CourseViewModel
    {
		public static CourseViewModel FromCourse(Course course)
		{
			return new CourseViewModel()
			{
				Id = course.Id,
				Name = course.Name,
				Description = course.Description,
				ClusterId = course.Cluster.Id,
				Cluster = course.Cluster.Description
			};
		}
		
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string Cluster { get; set; }

        [UIHint("ClusterId")]
        public int ClusterId { get; set; }
    }
}