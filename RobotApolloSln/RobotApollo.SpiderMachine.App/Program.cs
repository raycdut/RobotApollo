using RobotApollo.SpiderMachine.App.wanda;
using System;
namespace RobotApollo.SpiderMachine.App
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                LogHelper.WriteLog(typeof(Program), "Spider machine start at:" + DateTime.Now.ToLongTimeString());
                WandaSpider.WandaSpiderRun();
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(Program), ex);
            }


        }
    }
}
