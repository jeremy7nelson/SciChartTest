using Prism.Mvvm;
using SciChart.Charting.Model.ChartSeries;
using SciChart.Charting.Model.DataSeries;
using System;
using System.Collections.ObjectModel;
using System.Timers;

namespace ViewModel
{
    public class PlotViewModel : BindableBase, IDisposable
    {
        public ObservableCollection<IRenderableSeriesViewModel> RenderableSeries { get; } = new ObservableCollection<IRenderableSeriesViewModel>();

        private readonly Timer timer = new Timer(1000.0);
        private readonly XyDataSeries<double, double> series = new XyDataSeries<double, double>();
        public PlotViewModel()
        {
            RenderableSeries.Add(new LineRenderableSeriesViewModel() { DataSeries = series });
            timer.Elapsed += (x, y) => OnTimer();
            timer.Start();
        }

        private double x;
        private readonly Random random = new Random();
        private void OnTimer()
        {
            series.Append(x++, random.NextDouble());
        }

        #region Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
                timer.Dispose();

            disposed = true;
        }
        #endregion
    }
}
