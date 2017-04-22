using System;
namespace RobotApollo.SpiderMachine.App
{
    class Program
    {
        static void Main(string[] args)
        {
            LogHelper.WriteLog(typeof(Program), "Sprider machine start at:" + DateTime.Now.ToLongTimeString());

            Console.ReadKey();

        }
    }
}
