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
            var videoContainer = page.Selectable.Select(Selectors.XPath("//div[@class='tagContent']"));
            if (videoContainer != null)
            {
                var movieList = videoContainer.SelectList(Selectors.XPath("//dl/a")).Nodes();
                foreach (ISelectable item  in movieList)
                {
                    if (!string.IsNullOrEmpty(item.GetValue()))
                    {
                        results.Add(new WandaFilm()
                        {
                            MovieName = item.GetValue()
                        });
                    }
                }
            }

            page.AddResultItem("VideoResult", results);

            /*
            // 利用 Selectable 查询并构造自己想要的数据对象
            var totalVideoElements = page.Selectable.SelectList(Selectors.XPath("//div[@class='yk-pack pack-film']")).Nodes();
            
            foreach (var videoElement in totalVideoElements)
            {
                var video = new WandaFilm()
                {
                    Name = videoElement.Select(Selectors.XPath(".//img[@class='quic']/@alt")).GetValue()
                };
                results.Add(video);
            }

            // Save data object by key. 以自定义KEY存入page对象中供Pipeline调用
            

            // Add target requests to scheduler. 解析需要采集的URL
            foreach (var url in page.Selectable.SelectList(Selectors.XPath("//ul[@class='yk-pages']")).Links().Nodes())
            {
                page.AddTargetRequest(new Request(url.GetValue(), null));
            }*/
        }
    }
}