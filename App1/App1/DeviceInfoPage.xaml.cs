using Plugin.DeviceInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
	public partial class DeviceInfoPage : ContentPage
	{
		public DeviceInfoPage()
		{
			InitializeComponent();
            InitializePlugin();
		}

        private void InitializePlugin()
        {
            if (!CrossDeviceInfo.IsSupported)
            {
                DisplayAlert("Error", "Hubo un problema para inicializar el plugin o no es soportable", "OK");
                return;
            }

            var deviceInfo = CrossDeviceInfo.Current;

            Id.Text = deviceInfo.Id;
            Model.Text = deviceInfo.Model;
            Manufacturer.Text = deviceInfo.Manufacturer;
            DeviceName.Text = deviceInfo.DeviceName;
            Version.Text = deviceInfo.Version;
            VersionNumber.Text = $"{deviceInfo.VersionNumber.Major}.{deviceInfo.VersionNumber.Minor}";
            AppVersion.Text = deviceInfo.AppVersion;
            AppBuild.Text = deviceInfo.AppBuild;
            Platform.Text = deviceInfo.Platform.ToString();
            Idiom.Text = deviceInfo.Idiom.ToString();
        }
    }
}
