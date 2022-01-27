using Prism.Mvvm;
using SciChart.Charting.Model.ChartSeries;
using SciChart.Charting.Model.DataSeries;
using System.Collections.ObjectModel;

namespace ViewModel
{
    public class PlotViewModel : BindableBase
    {
        public ObservableCollection<IRenderableSeriesViewModel> RenderableSeries { get; } = new ObservableCollection<IRenderableSeriesViewModel>();

        public PlotViewModel()
        {
            var series = new XyDataSeries<double, double>();
            series.Append(0.0, 1e-8);
            series.Append(1.0, 1e-7);
            series.Append(2.0, 1e-6);
            series.Append(3.0, 1e-5);
            series.Append(4.0, 1e-4);
            RenderableSeries.Add(new ColumnRenderableSeriesViewModel() { DataSeries = series, ZeroLineY = 1e-7 });
        }
    }
}
