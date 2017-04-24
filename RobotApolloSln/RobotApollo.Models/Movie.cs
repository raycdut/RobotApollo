using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotApollo.Models
{
    public class Movie : BaseEntity
    {
        public int Id { get; set; }
        public DateTime? ShowDate { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public string DetailsUrl { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        public string Type { get; set; }
        public string Country { get; set; }
        public string Edition { get; set; }
        public string Length { get; set; }
        public string LogDesc { get; set; }

        public virtual ICollection<MoviePhoto> MoviePhotos { get; set; }
    }
}
