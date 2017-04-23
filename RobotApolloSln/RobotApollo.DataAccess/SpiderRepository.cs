using RobotApollo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotApollo.DataAccess
{
    public class SpiderRepository
    {
        private SpiderDB DB;
        public SpiderRepository()
        {
            DB = new SpiderDB();
        }


        public void SaveFilmData(Movie movie)
        {
            DB.Movies.Add(movie);
            DB.SaveChanges();
        }
    }
}
