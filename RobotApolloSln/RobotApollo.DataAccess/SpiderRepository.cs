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
                tmp.FilmId = movie.FilmId;
                tmp.CanWatch = movie.CanWatch;
            }
           
            DB.SaveChanges();
        }

        public void UpdateFileData(Movie movie)
        {
            var tmp = DB.Movies.FirstOrDefault(i => i.FilmId == movie.FilmId);
            if (tmp != null)
            {
                tmp.UpdatedBy = "SpiderMachine";
                tmp.UpdatedDate = DateTime.Now;
                tmp.Director = movie.Director;
                tmp.Actors = movie.Actors;
                tmp.Type = movie.Type;
                tmp.Country = movie.Country;
                tmp.Edition = movie.Edition;
                tmp.Length = movie.Length;
                tmp.LogDesc = movie.LogDesc;
            }
            DB.SaveChanges();
        }


        public List<Movie> GetFilmData()
        {
            return DB.Movies.Where(i => i.ShowDate > DateTime.Now || i.CanWatch == true).ToList();
        }
    }
}
