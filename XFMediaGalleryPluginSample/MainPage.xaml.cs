using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NativeMedia;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XFMediaGalleryPluginSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnPickImagesClick(object sender, EventArgs args)
        {
            var results = await MediaGallery.PickAsync(3, MediaFileType.Image, MediaFileType.Video);

            if (results?.Files == null)
            {
                return;
            }

            foreach (var media in results.Files)
            {
                var fileName = media.NameWithoutExtension;
                var extension = media.Extension;
                var contentType = media.ContentType;

                await DisplayAlert(fileName, $"Extension: {extension}, Content-type: {contentType}", "OK");
            }
        }

        private async void OnSaveImageClick(object sender, EventArgs args)
        {
            var screenshot = await Screenshot.CaptureAsync();

            await MediaGallery.SaveAsync(MediaFileType.Image, await screenshot.OpenReadAsync(), "myScreenshot.png");
        }
    }
}
