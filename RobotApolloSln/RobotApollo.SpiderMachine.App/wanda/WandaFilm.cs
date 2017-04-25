using System;

namespace RobotApollo.SpiderMachine.App.wanda
{
    internal class WandaFilm
    {
        public string MovieName { get; internal set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public string FilmId
        {
            get
            {
                var id = string.Empty;

                if (Url.EndsWith(".html")) {


                    id = Url.Substring(Url.LastIndexOf('_')+1).TrimEnd(".html".ToCharArray());
                }
                else
                {
                    id = Url.Substring(Url.LastIndexOf('=')+1);
                }

                return id;

            }
        }

        public string ID { get; set; }
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