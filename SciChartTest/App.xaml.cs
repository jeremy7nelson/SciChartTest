using System;

[assembly: CLSCompliant(false)]

namespace SciChartTest
{
    internal sealed partial class App
    {
        public App()
        {
            AppDomain.CurrentDomain.FirstChanceException += OnFirstChanceException;
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
        }

        private void OnFirstChanceException(object sender, System.Runtime.ExceptionServices.FirstChanceExceptionEventArgs e)
        {
            Log.Append("First chance exception:\n{0}", e.Exception);
        }

        private void OnUnhandledException(object sender, UnhandledExceptionEventArgs args)
        {
            Log.Append("Unhandled exception:\n{0}", (Exception)args.ExceptionObject);
        }
    }
}
