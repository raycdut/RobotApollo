using System;
using DotnetSpider.Core;
using DotnetSpider.Core.Processor;
using DotnetSpider.Extension.Model;
using DotnetSpider.Core.Selector;

namespace RobotApollo.SpiderMachine.App.wanda
{
    internal class WandaDetailPageProcessor : BasePageProcessor
    {
        protected override void Handle(Page page)
        {
            WandaFilm film = new WandaFilm();
            //film.ID = page.Selectable.Select(Selectors.XPath("//*[@id='filmId']")).GetValue();
            film.Url = page.Url;
            var dlList = page.Selectable.SelectList(Selectors.XPath("//div[@class='info_details']/dl/dd")).Nodes();
            film.Director = dlList[0].GetValue().Trim();
            film.Actors = dlList[1].GetValue().Trim();
            film.Type = dlList[2].GetValue().Trim();
            film.Country = dlList[3].GetValue().Trim();
            film.Edition = dlList[4].GetValue().Trim();
            film.Length = dlList[5].GetValue().Trim();
            film.LogDesc = page.Selectable.Select(Selectors.XPath("//div[@class='story']/p")).GetValue().Trim().TrimStart("<!-- 不要折行，折行会使两个连接的字之间有空格 -->".ToCharArray());


            page.AddResultItem("VideoResult", film);

        }
    }
}