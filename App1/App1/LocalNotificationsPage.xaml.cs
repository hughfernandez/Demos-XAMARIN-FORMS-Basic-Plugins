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
	public partial class LocalNotificationsPage : ContentPage
	{
		public LocalNotificationsPage ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTextBadge.Text) || string.IsNullOrEmpty(txtTitleBadge.Text) || string.IsNullOrEmpty(txtTimeBadge.Text))
            {
                return;
            }

            Plugin.LocalNotifications.CrossLocalNotifications.Current.Show(txtTitleBadge.Text,txtTextBadge.Text,0,DateTime.Now.AddSeconds(double.Parse(txtTimeBadge.Text)));
        }
    }
}