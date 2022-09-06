using App20.Interfaces;
using App20.UWP.Dependency;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(NLogManager))]
namespace App20.UWP.Dependency
{
    public class NLogManager : ILogManager
    {
        public NLogManager()
        {
            var config = new NLog.Config.LoggingConfiguration();

            // target where to log to
           // string path = "C:\\temp";
            //var logfile = new NLog.Targets.FileTarget("logfile") { FileName = path + @"\log.txt" };
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");

            // rules for mapping loggers to targets
            // minimum and maximum log levels for logging targets
            config.AddRule(NLog.LogLevel.Info, NLog.LogLevel.Fatal, logconsole);
            //config.AddRule(NLog.LogLevel.Info, NLog.LogLevel.Fatal, logfile);

            LogManager.Configuration = config;
        }


        App20.Interfaces.ILogger ILogManager.GetLog(string callerFilePath)
        {
            string fileName = callerFilePath;

            if (fileName.Contains("/"))
            {
                fileName = fileName.Substring(fileName.LastIndexOf("/", StringComparison.CurrentCultureIgnoreCase) + 1);
            }

            var logger = LogManager.GetLogger(fileName);
            return new NLogLogger(logger);
        }
    }
}

