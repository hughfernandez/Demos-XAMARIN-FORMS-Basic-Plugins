using Plugin.Connectivity;
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
	public partial class CheckConnectionPage : ContentPage
	{
		public CheckConnectionPage ()
		{
			InitializeComponent ();
            InitializePlugin();
		}

        private void InitializePlugin()
        {
            if (!CrossConnectivity.IsSupported)
            {
                DisplayAlert("Error de plugin", "Error al cargar el plugin", "OK");
                return;
            }

            CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
            CrossConnectivity.Current.ConnectivityTypeChanged += Current_ConnectivityTypeChanged;            
        }

        private void Current_ConnectivityChanged(object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e)
        {
            
        }

        private void Current_ConnectivityTypeChanged(object sender, Plugin.Connectivity.Abstractions.ConnectivityTypeChangedEventArgs e)
        {
            status.Text = CrossConnectivity.Current.IsConnected ? "Conectado" : "No conectado";
            var connectionTypes = CrossConnectivity.Current.ConnectionTypes;
            types.ItemsSource = connectionTypes;            
        }
    }
}