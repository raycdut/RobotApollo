using System;

namespace RobotApollo.SpiderMachine.App.wanda
{
    internal class WandaFilm
    {
        public string MovieName { get; internal set; }

        public string Description { get; set; }

        public string Url { get; set; }
        public bool CanWatch { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        public string Type { get; set; }
        public string Country { get; set; }
        public string Edition { get; set; }
        public string Length { get; set; }
        public string LogDesc { get; set; }

        public DateTime MovieTime { get; set; }
    }
}