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
	public partial class SettingsPage : ContentPage
	{
		public SettingsPage ()
		{
			InitializeComponent ();            
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            parametro1.Text = Helpers.Settings.GeneralSettings;
        }
        private void Button_Pressed(object sender, EventArgs e)
        {
            Helpers.Settings.GeneralSettings = parametro1.Text;
            DisplayAlert("Guardar", "Cambios guardados", "OK");
        }
    }
}