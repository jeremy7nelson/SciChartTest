using System;
using System.IO;

namespace SciChartTest
{
    public partial class App
    {
        public App()
        {
            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;
        }

        private void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs args)
        {
            File.AppendAllText("Error.log", ((Exception)args.ExceptionObject).ToString() + Environment.NewLine + Environment.NewLine);
        }
    }
}
