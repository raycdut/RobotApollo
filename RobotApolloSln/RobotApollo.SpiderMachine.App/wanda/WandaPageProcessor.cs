using System;
using DotnetSpider.Core;
using DotnetSpider.Core.Processor;
using System.Collections.Generic;
using DotnetSpider.Core.Selector;

namespace RobotApollo.SpiderMachine.App.wanda
{
    internal class WandaPageProcessor : BasePageProcessor
    {

        protected override void Handle(Page page)
        {
            List<WandaFilm> results = new List<WandaFilm>();

            LogHelper.WriteLog(typeof(WandaPageProcessor), "process current show ");
            var videoContainer = page.Selectable.Select(Selectors.XPath("//div[@id='tagContent0']"));
            if (videoContainer != null)
            {
                var movieList = videoContainer.SelectList(Selectors.XPath("//div[@id='tagContent0']/ul/li")).Nodes();
                int cnt = 1;
                foreach (var item in movieList)
                {
                    var aname = item.Select(Selectors.XPath(string.Format("//div[@id='tagContent0']/ul/li[{0}]/dl/a", cnt)));
                    var aDesc = item.Select(Selectors.XPath(string.Format("//div[@id='tagContent0']/ul/li[{0}]/div/div/a[@class='awhite home_talk2']", cnt)));

                    if (!string.IsNullOrEmpty(aname.GetValue()))
                    {
                        var url = aname.Links().Nodes()[0].GetValue();
                        //page.AddTargetRequest(new Request(url, null));

                        results.Add(new WandaFilm()
                        {
                            MovieName = aname.GetValue(),
                            Description = aDesc.GetValue(),
                            Url = url,
                            
                        });
                    }
                    cnt += 1;
                }
            }


            var willshowContainer = page.Selectable.Select(Selectors.XPath("//div[@id='tagContent1']"));
            if (willshowContainer != null)
            {
                var movieList = willshowContainer.SelectList(Selectors.XPath("//div[@id='tagContent1']/ul/li")).Nodes();
                int cnt = 1;
                foreach (var item in movieList)
                {
                    var aname = item.Select(Selectors.XPath(string.Format("//div[@id='tagContent1']/ul/li[{0}]/dl/a[@class='moviename']", cnt)));
                    var aDesc = item.Select(Selectors.XPath(string.Format("//div[@id='tagContent1']/ul/li[{0}]/div/div/a[@class='awhite home_talk2']", cnt)));
                    var movietime = item.Select(Selectors.XPath(string.Format("//div[@id='tagContent1']/ul/li[{0}]/dl/div[@class='movie_time']", cnt)));
                    if (!string.IsNullOrEmpty(aname.GetValue()))
                    {
                        var url = aname.Links().Nodes()[0].GetValue();
                        //page.AddTargetRequest(new Request(url, null));
                        var md = movietime.GetValue().Trim().Replace("月", "-").Replace("日", "-").Split('-');
                        var time = new DateTime(DateTime.Now.Year, int.Parse(md[0]), int.Parse(md[1]));

                        results.Add(new WandaFilm()
                        {
                            MovieName = aname.GetValue(),
                            Description = aDesc.GetValue(),
                            Url = url,
                            MovieTime = time
                        });
                    }
                    cnt += 1;
                }
            }

            page.AddResultItem("VideoResult", results);


            //foreach (var url in results)
            //{
            //    page.AddTargetRequest(new Request(url.Url, null));
            //}
        }
    }
}