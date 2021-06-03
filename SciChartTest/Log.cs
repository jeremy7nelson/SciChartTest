using System;
using System.IO;
using System.Text.RegularExpressions;

namespace SciChartTest
{
    public static class Log
    {
        public static void Append(string format, params object[] args)
        {
            string message = string.Format(format, args);
            string text = string.Format("{0}\n{1}\n\n", DateTime.Now, message);
            File.AppendAllText("Log.txt", Regex.Replace(text, @"\r\n?|\n", Environment.NewLine));
        }
    }
}
