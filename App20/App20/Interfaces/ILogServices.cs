using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace App20.Interfaces
{
    public interface ILogger
    {
        void Trace(string text, params object[] args);
        void Debug(string text, params object[] args);
        void Info(string text, params object[] args);
        void Warn(string text, params object[] args);
        void Error(string text, params object[] args);
        void Fatal(string text, params object[] args);
    }

    public interface ILogManager
    {
        ILogger GetLog([System.Runtime.CompilerServices.CallerFilePath] string callerFilePath = "");
    }
}
