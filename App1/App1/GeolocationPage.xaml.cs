using Plugin.Compass;
using Plugin.Compass.Abstractions;
using Plugin.Geolocator;
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
	public partial class GeolocationPage : ContentPage
	{
		public GeolocationPage ()
		{
			InitializeComponent ();
            InitializeGeolocationPlugin();
            InitializeCompassPlugin();
		}

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            CrossGeolocator.Current.StopListeningAsync();
            CrossCompass.Current.Stop();
        }

        private async void InitializeCompassPlugin()
        {
            if (!CrossCompass.IsSupported)
            {
                await DisplayAlert("Error", "Ha ocurrido un error al cargar el plugin", "OK");
                return;
            }

            CrossCompass.Current.CompassChanged += Current_CompassChanged;
            CrossCompass.Current.Start();
        }

        private void Current_CompassChanged(object sender, Plugin.Compass.Abstractions.CompassChangedEventArgs e)
        {
            compass.Text = e.Heading.ToString();
        }

        private async void InitializeGeolocationPlugin()
        {
            if (!CrossGeolocator.IsSupported)
            {
                await DisplayAlert("Error", "Ha ocurrido un error al cargar el plugin", "OK");
                return;
            }

            if (!CrossGeolocator.Current.IsGeolocationEnabled || !CrossGeolocator.Current.IsGeolocationAvailable)
            {
                await DisplayAlert("Advertencia", "Revise la configuracion GPS de su dispositivo", "OK");
                return;
            }

            CrossGeolocator.Current.PositionChanged += Current_PositionChanged;

            await CrossGeolocator.Current.StartListeningAsync(new TimeSpan(0,0,1), 0.5);
        }

        private void Current_PositionChanged(object sender, Plugin.Geolocator.Abstractions.PositionEventArgs e)
        {
            if (!CrossGeolocator.Current.IsListening)
            {
                return;
            }

            var position = CrossGeolocator.Current.GetPositionAsync();

            lat.Text = position.Result.Latitude.ToString();
            lon.Text = position.Result.Longitude.ToString();
            altimetry.Text = position.Result.Altitude.ToString();
        }
    }
}