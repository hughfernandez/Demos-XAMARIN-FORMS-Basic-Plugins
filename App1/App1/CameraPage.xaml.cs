using App1.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CameraPage : ContentPage
	{
        ObservableCollection<MediaModel> Photos = new ObservableCollection<MediaModel>();

		public CameraPage ()
		{
			InitializeComponent ();            
		}

        private async void photoButton_Pressed(object sender, EventArgs e)
        {
            var isInitialize = await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported || !CrossMedia.IsSupported || !isInitialize)
            {
                await DisplayAlert("Error", "La camara no se encuentra disponible", "OK");
                return;
            }

            var newPhotoID = Guid.NewGuid();

            using (var photo = await CrossMedia.Current.TakePhotoAsync(
                new StoreVideoOptions()
                {
                    Name = newPhotoID.ToString(),
                    SaveToAlbum = true,
                    DefaultCamera = CameraDevice.Rear,
                    Directory = "Demo Camara"
                }))
            {
                if (string.IsNullOrWhiteSpace(photo?.Path))
                {
                    return;
                }

                var newPhotoMedia = new MediaModel()
                {
                    MediaID = newPhotoID,
                    Path = photo.Path,
                    LocalDateTime = DateTime.Now
                };

                Photos.Add(newPhotoMedia);

                photo.Dispose();
            }

            listPhotos.ItemsSource = Photos;
        }
    }
}