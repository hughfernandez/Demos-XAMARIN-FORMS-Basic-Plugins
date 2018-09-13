using Plugin.Battery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BatteryStatusPage : ContentPage
	{
		public BatteryStatusPage ()
		{
			InitializeComponent ();
            InitializePlugin();
		}

        private void InitializePlugin()
        {
            if (!CrossBattery.IsSupported)
            {
                DisplayAlert("Error de plugin", "Hubo un error al cargar el plugin de bateria", "OK");
                return;
            }

            var batteryStatus = CrossBattery.Current;

            percent.Text = $"{batteryStatus.RemainingChargePercent}%";            

            batteryStatus.BatteryChanged += BatteryStatus_BatteryChanged;
        }

        private void BatteryStatus_BatteryChanged(object sender, Plugin.Battery.Abstractions.BatteryChangedEventArgs e)
        {
            status.Text = CrossBattery.Current.Status.ToString();
        }
    }
}