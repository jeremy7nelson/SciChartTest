using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace SciChartTest
{
    internal static class Log
    {
#if NET9_0_OR_GREATER
        private static readonly Lock logLock = new();
#else
        private static readonly object logLock = new();
#endif
        public static void Append(string format, params object[] args)
        {
            lock (logLock)
            {
                string message = string.Format(CultureInfo.InvariantCulture, format, args);
                string text = string.Format(CultureInfo.InvariantCulture, "{0}\n{1}\n\n", DateTime.Now, message);
                File.AppendAllText("Log.txt", Regex.Replace(text, @"\r\n?|\n", Environment.NewLine));
            }
        }
    }
}
