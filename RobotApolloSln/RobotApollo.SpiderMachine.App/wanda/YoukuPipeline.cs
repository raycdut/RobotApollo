using System;
using DotnetSpider.Core;
using DotnetSpider.Core.Pipeline;

namespace RobotApollo.SpiderMachine.App.wanda
{
    internal class YoukuPipeline : BasePipeline
    {
        private static long count = 0;

        public override void Process(ResultItems resultItems)
        {
            foreach (YoukuVideo entry in resultItems.Results["VideoResult"])
            {
                count++;
                Console.WriteLine($"[YoukuVideo {count}] {entry.Name}");
            }

            // Other actions like save data to DB. 可以自由实现插入数据库或保存到文件
        }

    }
}