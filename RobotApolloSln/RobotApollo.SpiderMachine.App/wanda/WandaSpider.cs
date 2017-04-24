using DotnetSpider.Core;
using DotnetSpider.Core.Downloader;
using DotnetSpider.Core.Scheduler;
using RobotApollo.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotApollo.SpiderMachine.App.wanda
{
    public class WandaSpider
    {
        public static void WandaSpiderRun()
        {

            LogHelper.WriteLog(typeof(WandaSpider), "Start to get data from wanda website");

            var site = new Site { EncodingName = "UTF-8", RemoveOutboundLinks = true };
            site.AddStartUrl("http://www.wandafilm.com/");
            Spider spider = Spider.Create(site,
                new QueueDuplicateRemovedScheduler(),
                new WandaPageProcessor())
                .AddPipeline(new WandaPipeline())
                .SetDownloader(new HttpClientDownloader())
                .SetThreadNum(1);

            spider.EmptySleepTime = 3000;

            spider.Run();
        }

        public static void WandaDetailsSpiderRun()
        {
            var rep = new SpiderRepository();

            var site = new Site { EncodingName = "UTF-8", RemoveOutboundLinks = true };
            foreach (var item in rep.GetFilmData())
            {
                site.AddStartUrl(item.DetailsUrl);
            }
            Spider spider = Spider.Create(site,
                new QueueDuplicateRemovedScheduler(),
                new WandaDetailPageProcessor())
                .AddPipeline(new WandaDetailPipeline())
                .SetDownloader(new HttpClientDownloader())
                .SetThreadNum(1);

            spider.EmptySleepTime = 3000;

            spider.Run();
        }
    }
}
