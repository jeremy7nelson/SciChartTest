using Prism.Mvvm;
using SciChart.Charting.Model.ChartSeries;
using SciChart.Charting.Model.DataSeries;
using SciChart.Charting.Visuals.Annotations;
using System;
using System.Collections.ObjectModel;

namespace ViewModel
{
    public class PlotViewModel : BindableBase
    {
        public ObservableCollection<IRenderableSeriesViewModel> RenderableSeries { get; } = new ObservableCollection<IRenderableSeriesViewModel>();
        public AnnotationCollection Annotations { get; } = new AnnotationCollection();

        public PlotViewModel()
        {
            int count = 1000000;
            for (int i = 0; i < 100; i++)
            {
                var series = new XyDataSeries<double, double>();
                var xData = new double[count];
                var yData = new double[count];
                for (int j = 0; j < count; j++)
                {
                    double x = j * 1e-4;
                    xData[j] = x;
                    yData[j] = i * Math.Sin(x);
                }
                series.Append(xData, yData);
                RenderableSeries.Add(new LineRenderableSeriesViewModel() { DataSeries = series });
            }

            Annotations.Add(new VerticalLineAnnotation() { X1 = Math.PI * 0.5 });
            Annotations.Add(new VerticalLineAnnotation() { X1 = Math.PI * 1.5 });
            Annotations.Add(new VerticalLineAnnotation() { X1 = Math.PI * 2.5 });
        }
    }
}
