using System;
using DotnetSpider.Core;
using DotnetSpider.Core.Processor;
using System.Collections.Generic;
using DotnetSpider.Core.Selector;

namespace RobotApollo.SpiderMachine.App.wanda
{
    internal class YoukuPageProcessor: BasePageProcessor
    {

        protected override void Handle(Page page)
        {
            // 利用 Selectable 查询并构造自己想要的数据对象
            var totalVideoElements = page.Selectable.SelectList(Selectors.XPath("//div[@class='yk-pack pack-film']")).Nodes();
            List<YoukuVideo> results = new List<YoukuVideo>();
            foreach (var videoElement in totalVideoElements)
            {
                var video = new YoukuVideo()
                {
                    Name = videoElement.Select(Selectors.XPath(".//img[@class='quic']/@alt")).GetValue()
                };
                results.Add(video);
            }

            // Save data object by key. 以自定义KEY存入page对象中供Pipeline调用
            page.AddResultItem("VideoResult", results);

            // Add target requests to scheduler. 解析需要采集的URL
            foreach (var url in page.Selectable.SelectList(Selectors.XPath("//ul[@class='yk-pages']")).Links().Nodes())
            {
                page.AddTargetRequest(new Request(url.GetValue(), null));
            }
        }
    }
}