using Prism.Mvvm;
using SciChart.Charting.Model.ChartSeries;
using SciChart.Charting.Model.DataSeries.Heatmap2DArrayDataSeries;
using SciChart.Charting.Visuals.RenderableSeries;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace ViewModel
{
    public class PlotViewModel : BindableBase
    {
        public ObservableCollection<IRenderableSeriesViewModel> RenderableSeries { get; } = new ObservableCollection<IRenderableSeriesViewModel>();

        public PlotViewModel()
        {
            var zValues = new double[3, 3] { { 1.0, 0.0, 1.0 }, { 0.0, -1.0, 0.0 }, { 1.0, 0.0, 1.0 } };
            var dataSeries = new UniformHeatmapDataSeries<double, double, double>(zValues, 0.0, 1.0, 0.0, 1.0);
            var heatmap = new UniformHeatmapRenderableSeriesViewModel() { DataSeries = dataSeries };
            heatmap.ColorMap = new HeatmapColorPalette()
            {
                AllowsHighPrecision = true,
                Minimum = -1.0,
                Maximum = 1.0,
                GradientStops = new(new[]
                {
                    new GradientStop(Colors.Red, -1.0),
                    new GradientStop(Colors.Black, 0.0),
                    new GradientStop(Colors.Green, 1.0)
                 })
            };
            RenderableSeries.Add(heatmap);
        }
    }
}
