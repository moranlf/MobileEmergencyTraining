using System;
using System.Collections.Generic;
using System.Linq;
using MobileBasedTrainingServer.Models;
using System.ComponentModel.DataAnnotations;

namespace MobileBasedTrainingServer.ViewModels
{
	public class VideoViewModel 
	{
		public VideoViewModel()
        {
            this.Ratings = new HashSet<Ratings>();
            this.Tags = new HashSet<Tags>();
        }

		public static VideoViewModel From(Video video)
		{
			var result = new VideoViewModel();
			result.Id = video.Id;
			result.Title = video.Title;
			result.Description = video.Description;
			result.PublicationDate = video.PublicationDate;
			result.Language = video.Language;
			result.URL = video.URL;
			result.PublisherName = video.PublisherName;
			result.PublicationDate = video.PublicationDate;
			result.PublisherEmail = video.PublisherEmail;
			result.Ratings = video.Ratings;
			result.Tags = video.Tags;

			return result;
		}

		public Video ToVideo()
		{
			var result = new Video();
			result.Id = Id;
			result.Title = Title;
			result.Description = Description;
			result.PublicationDate = PublicationDate;
			result.Language = Language;
			result.URL = URL;
			result.PublisherName = PublisherName;
			result.PublicationDate = PublicationDate;
			result.PublisherEmail = PublisherEmail;
			result.Ratings = Ratings;
			result.Tags = Tags;

			return result;
		}
 
		[ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required()]
        public string Title { get; set; }
		[UIHint("TextArea"),Required()]
        public string Description { get; set; }
        [Required()]
        public System.DateTime PublicationDate { get; set; }
        [Required()]
        public string Language { get; set; }
        [Required()]
        public string URL { get; set; }
        [Required()]
        public string PublisherName { get; set; }
        [Required()]
        public string PublisherEmail { get; set; }
        [Required()]
		public string ThumbnailURL
		{ 
			//TODO: Replace me
			//This is a placeholder until the database model has a ThumbnailURL property
			get
			{
				return string.Format("http://lorempixel.com/120/90/transport/{0}", (this.Id % 10) + 1);
			}
		}
    
        public virtual ICollection<Ratings> Ratings { get; set; }
        public virtual ICollection<Tags> Tags { get; set; }
	}
}