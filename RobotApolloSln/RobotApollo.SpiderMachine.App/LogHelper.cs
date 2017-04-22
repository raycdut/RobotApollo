using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace RobotApollo.SpiderMachine.App
{
    public class LogHelper
    {
        /// <summary>
        /// 输出日志到Log4Net
        /// </summary>
        /// <param name="t"></param>
        /// <param name="ex"></param>
        #region static void WriteLog(Type t, Exception ex)

        public static void WriteLog(Type t, Exception ex)
        {
            Trace.WriteLine(ex.Message);
            log4net.ILog log = log4net.LogManager.GetLogger(t);
            log.Error("Error", ex);
        }

        #endregion

        /// <summary>
        /// 输出日志到Log4Net
        /// </summary>
        /// <param name="t"></param>
        /// <param name="msg"></param>
        #region static void WriteLog(Type t, string msg)

        public static void WriteLog(Type t, string msg)
        {
            Trace.WriteLine(msg);
            log4net.ILog log = log4net.LogManager.GetLogger(t);
            log.Info(msg);
        }

        #endregion


    }
}
