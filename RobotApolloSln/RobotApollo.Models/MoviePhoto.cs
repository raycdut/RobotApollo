using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotApollo.Models
{
    public class MoviePhoto
    {
        public int Id { get; set; }

        public byte[] Image { get; set; }
        public string ImageType { get; set; }
    }
}
