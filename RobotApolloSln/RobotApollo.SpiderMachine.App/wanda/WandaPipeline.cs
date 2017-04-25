using System;
using DotnetSpider.Core;
using DotnetSpider.Core.Pipeline;
using RobotApollo.DataAccess;

namespace RobotApollo.SpiderMachine.App.wanda
{
    internal class WandaPipeline : BasePipeline
    {

        public override void Process(ResultItems resultItems)
        {
            var repository = new SpiderRepository();

            foreach (WandaFilm entry in resultItems.Results["VideoResult"])
            {

                repository.SaveFilmData(new Models.Movie()
                {
                    CreatedBy = "SpiderMachine",
                    CreatedDate = DateTime.Now,
                    Description = entry.Description,
                    Name = entry.MovieName,
                    ShowDate = entry.MovieTime,
                    DetailsUrl = entry.Url,
                    FilmId = entry.FilmId,
                    CanWatch = entry.CanWatch
                    
                    
                });
            }

            // Other actions like save data to DB. 可以自由实现插入数据库或保存到文件
        }

    }
}