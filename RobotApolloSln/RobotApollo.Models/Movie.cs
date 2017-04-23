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
    }
}
