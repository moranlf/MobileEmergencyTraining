//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MobileBasedTrainingServer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tags
    {
        public Tags()
        {
            this.Videos = new HashSet<Video>();
        }
    
        public int Id { get; set; }
        public string Tag { get; set; }
    
        public virtual ICollection<Video> Videos { get; set; }
    }
}