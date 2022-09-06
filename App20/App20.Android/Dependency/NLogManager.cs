using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App20.Droid.Dependency;
using App20.Interfaces;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[assembly: Xamarin.Forms.Dependency(typeof(NLogManager))]
namespace App20.Droid.Dependency
{
    public class NLogManager : ILogManager
    {
        public NLogManager()
        {
            var config = new NLog.Config.LoggingConfiguration();

            // target where to log to
            // string path = "C:\\Users\\SAI MUKESH R\\OneDrive\\Desktop\\Logs";
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