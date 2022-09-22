using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace App20.Droid.Dependency
{
    public class NLogLogger : App20.Interfaces.ILogger
    {
        private readonly Logger log;

        public NLogLogger(Logger log)
        {
            this.log = log;
        }

        public void Debug(string text, params object[] args)
        {
            log.Debug(text, args);
        }

        public void Error(string text, params object[] args)
        {
            log.Error(text, args);
        }

        public void Fatal(string text, params object[] args)
        {
            log.Fatal(text, args);
        }

        public void Info(string text, params object[] args)
        {
            log.Info(text, args);
        }

        public void Trace(string text, params object[] args)
        {
            log.Trace(text, args);
        }

        public void Warn(string text, params object[] args)
        {
            log.Warn(text, args);
        }

    }
}