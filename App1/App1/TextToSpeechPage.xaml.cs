using Plugin.TextToSpeech;
using Plugin.TextToSpeech.Abstractions;
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
	public partial class TextToSpeechPage : ContentPage
	{
        static CrossLocale? locale = null;
		public TextToSpeechPage ()
		{
			InitializeComponent ();
		}

        private async void speakButton_Clicked(object sender, EventArgs e)
        {
            speakButton.IsEnabled = false;

            var text = txtToSpeech.Text;
            if (useDefaults.IsToggled)
            {
                await CrossTextToSpeech.Current.Speak(text);
                speakButton.IsEnabled = true;
                return;
            }

            await CrossTextToSpeech.Current.Speak(text,
                pitch: (float)sliderPitch.Value,
                speakRate: (float)sliderPitch.Value,
                volume: (float)sliderVolume.Value,
                crossLocale: locale);

            speakButton.IsEnabled = true;
        }

        private async void languageButton_Clicked(object sender, EventArgs e)
        {
            var locales = await CrossTextToSpeech.Current.GetInstalledLanguages();
            var items = locales.Select(a => a.ToString()).ToArray();

            var selected = await DisplayActionSheet("Idioma", "OK", null, items); //en-US - es-ES
            if (string.IsNullOrWhiteSpace(selected) || selected == "OK")
                return;

            if (Device.RuntimePlatform == Device.Android)
            {
                locale = locales.FirstOrDefault(l => l.ToString() == selected);
            }
            else
            {
                locale = new CrossLocale { Language = selected }; //UWP/IOS
            }
        }

        
    }
}