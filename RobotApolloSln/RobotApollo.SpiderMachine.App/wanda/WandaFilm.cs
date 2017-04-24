using System;

namespace RobotApollo.SpiderMachine.App.wanda
{
    internal class WandaFilm
    {
        public string MovieName { get; internal set; }

        public string Description { get; set; }

        public string Url { get; set; }
        public DateTime MovieTime { get; internal set; }
    }
}