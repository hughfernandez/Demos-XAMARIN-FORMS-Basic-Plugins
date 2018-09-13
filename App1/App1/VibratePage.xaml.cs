using Plugin.Vibrate;
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
	public partial class VibratePage : ContentPage
	{
		public VibratePage ()
		{
			InitializeComponent ();
		}

        private void Button_Pressed(object sender, EventArgs e)
        {
            if (!CrossVibrate.IsSupported)
            {
                return;
            }

            if (!CrossVibrate.Current.CanVibrate)
            {
                return;
            }

            CrossVibrate.Current.Vibration(new TimeSpan(0, 0, 2));                
        }
    }
}