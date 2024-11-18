using Prism.Mvvm;
using SciChart.Charting.Model.ChartSeries;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Threading;

namespace ViewModel
{
    [SuppressMessage("Performance", "CA1812:Avoid uninstantiated internal classes")]
    internal sealed class PlotViewModel : BindableBase, IDisposable
    {
        public ObservableCollection<IRenderableSeriesViewModel> RenderableSeries { get; } = [];

        private readonly Dispatcher dispatcher = Dispatcher.CurrentDispatcher;
        private readonly System.Timers.Timer timer = new(10.0);
        private readonly LineRenderableSeriesViewModel renderable = new();
        public PlotViewModel()
        {
            timer.Elapsed += (x, y) => dispatcher.Invoke(ReplaceRenderableSeries);
            timer.Start();
        }

        private void ReplaceRenderableSeries()
        {
            RenderableSeries.Clear();
            RenderableSeries.Add(renderable);
        }

        #region Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed;
        private void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                timer.Dispose();
            }

            disposed = true;
        }
        #endregion
    }
}
