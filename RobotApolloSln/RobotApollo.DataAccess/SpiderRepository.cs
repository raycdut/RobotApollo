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
            var tmp = DB.Movies.FirstOrDefault(i => i.Name == movie.Name);
            if (tmp == null)
            {
                if (movie.ShowDate == DateTime.MinValue)
                {
                    movie.ShowDate = DateTime.Now;
                }
                DB.Movies.Add(movie);
            }
            else
            {
                tmp.UpdatedBy = "SpiderMachine";
                tmp.UpdatedDate = DateTime.Now;
                tmp.Description = movie.Description;
                tmp.DetailsUrl = movie.DetailsUrl;
             
            }
           
            DB.SaveChanges();
        }

        public List<Movie> GetFilmData()
        {
            return DB.Movies.Where(i => i.ShowDate > DateTime.Now || i.CanWatch == true).ToList();
        }
    }
}
