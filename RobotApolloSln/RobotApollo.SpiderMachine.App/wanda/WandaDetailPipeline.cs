using System;
using DotnetSpider.Core;
using DotnetSpider.Core.Pipeline;
using DotnetSpider.Core.Processor;
using RobotApollo.DataAccess;

namespace RobotApollo.SpiderMachine.App.wanda
{
    internal class WandaDetailPipeline : BasePipeline
    {
        public override void Process(ResultItems resultItems)
        {
            var movie = resultItems.Results["VideoResult"] as WandaFilm;
            new SpiderRepository().UpdateFileData(new Models.Movie()
            {
                FilmId = movie.FilmId,
                Director = movie.Director,
                Actors = movie.Actors,
                Type = movie.Type,
                Country = movie.Country,
                Edition = movie.Edition,
                Length = movie.Length,
                LogDesc = movie.LogDesc
            });
        }
    }
}