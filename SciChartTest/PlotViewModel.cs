using Prism.Mvvm;
using SciChart.Charting.Model.ChartSeries;
using SciChart.Charting.Model.DataSeries;
using SciChartTest;
using System;
using System.Collections.ObjectModel;
using System.Threading;

namespace ViewModel
{
    public class PlotViewModel : BindableBase, IDisposable
    {
        public ObservableCollection<IRenderableSeriesViewModel> RenderableSeries { get; } = [];

        private bool enableVisualXcceleratorEngine;
        public bool EnableVisualXcceleratorEngine
        {
            get => enableVisualXcceleratorEngine;
            set => SetProperty(ref enableVisualXcceleratorEngine, value);
        }

        private bool enableImpossibleMode;
        public bool EnableImpossibleMode
        {
            get => enableImpossibleMode;
            set => SetProperty(ref enableImpossibleMode, value);
        }

        private bool enableExtremeResamplers;
        public bool EnableExtremeResamplers
        {
            get => enableExtremeResamplers;
            set => SetProperty(ref enableExtremeResamplers, value);
        }

        private readonly System.Timers.Timer timer = new(10.0);
        private readonly XyDataSeries<double, double> series = new();
        public PlotViewModel()
        {
            RenderableSeries.Add(new LineRenderableSeriesViewModel() { DataSeries = series });
            timer.Elapsed += (x, y) => OnTimer();
            timer.Start();
        }

        private double x;
        private readonly Random random = new();
        private int processingTimer;
        private void OnTimer()
        {
            if (Interlocked.Exchange(ref processingTimer, 1) == 0)
            {
                try
                {
                    series.Append(x++, random.NextDouble());
                    if (x % 1000 == 0)
                    {
                        ChangeRenderer();
                    }
                }
                catch (Exception e)
                {
                    Log.Append("Exception thrown from Append:\n{0}", e);
                }
                finally
                {
                    Interlocked.Exchange(ref processingTimer, 0);
                }
            }
        }

        bool vx;
        private void ChangeRenderer()
        {
            vx = !vx;
            EnableVisualXcceleratorEngine = vx;
            EnableImpossibleMode = vx;
            EnableExtremeResamplers = vx;
        }

        #region Dispose
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed;
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
