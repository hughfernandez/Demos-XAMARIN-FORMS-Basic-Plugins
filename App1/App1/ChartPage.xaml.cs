using Microcharts;
using SkiaSharp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChartPage : ContentPage
	{
		public ChartPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var entries = new[]
            {
                new Microcharts.Entry(212)
                {
                    Label = "UWP",
                    ValueLabel = "212",
                    Color = SKColor.Parse("#2c3e50")
                },
                new Microcharts.Entry(248)
                {
                    Label = "Android",
                    ValueLabel = "248",
                    Color = SKColor.Parse("#77d065")
                },
                new Microcharts.Entry(128)
                {
                    Label = "iOS",
                    ValueLabel = "128",
                    Color = SKColor.Parse("#b455b6")
                },
                new Microcharts.Entry(514)
                {
                    Label = "Shared",
                    ValueLabel = "514",
                    Color = SKColor.Parse("#3498db")
                } };

            var chart1 = new BarChart() { Entries = entries };
            var chart2 = new LineChart() { Entries = entries};
            var chart3 = new PointChart() { Entries = entries};
            var chart4 = new RadialGaugeChart() { Entries = entries};
            var chart5 = new DonutChart() { Entries = entries};
            var chart6 = new RadarChart() { Entries = entries };

            charView.Chart = chart1;
            charView1.Chart = chart2;
            charView2.Chart = chart3;
            charView3.Chart = chart4;
            charView4.Chart = chart5;
            charView5.Chart = chart6;
        }
    }
}