using DotnetSpider.Core;
using DotnetSpider.Core.Downloader;
using DotnetSpider.Core.Scheduler;
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

            // Config encoding, header, cookie, proxy etc... 定义采集的 Site 对象, 设置 Header、Cookie、代理等
            var site = new Site { EncodingName = "UTF-8", RemoveOutboundLinks = true };
            //for (int i = 1; i < 5; ++i)
            //{
            //    // Add start/feed urls. 添加初始采集链接
            //    site.AddStartUrl("http://" + $"www.youku.com/v_olist/c_97_g__a__sg__mt__lg__q__s_1_r_0_u_0_pt_0_av_0_ag_0_sg__pr__h__d_1_p_{i}.html");
            //}
            site.AddStartUrl("http://www.wandafilm.com/");
            Spider spider = Spider.Create(site,
                // use memoery queue scheduler. 使用内存调度
                new QueueDuplicateRemovedScheduler(),
                // use custmize processor for youku 为优酷自定义的 Processor
                new WandaPageProcessor())
                // use custmize pipeline for youku 为优酷自定义的 Pipeline
                .AddPipeline(new YoukuPipeline())
                // dowload html by http client
                .SetDownloader(new HttpClientDownloader())
                // 1 thread
                .SetThreadNum(1);

            spider.EmptySleepTime = 3000;

            // Start crawler 启动爬虫
            spider.Run();
        }
    }
}
