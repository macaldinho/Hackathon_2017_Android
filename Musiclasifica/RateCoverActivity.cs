using System.Linq;
using System.Net;
using System.Net.Http;
using System.Xml.Serialization;
using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using Musiclasifica.JsonResponse;
using Newtonsoft.Json;

namespace Musiclasifica
{
    [Activity(Label = "RateCoverActivity")]
    public class RateCoverActivity : Activity
    {
        const string ServiceUrl = "https://testloopbackvis.mybluemix.net/VisualRec?imageurl=";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.RateCover);

            var url = FindViewById<EditText>(Resource.Id.txtUrl);
            var image = FindViewById<ImageView>(Resource.Id.imgCover);
            var btnRateCover = FindViewById<Button>(Resource.Id.btnRateCover);

            image.Visibility = ViewStates.Invisible;

            btnRateCover.Click += async (s, e) =>
            {
                if (!string.IsNullOrWhiteSpace(url.Text))
                {
                    image.Visibility = ViewStates.Visible;
                    var imageBitmap = Util.GetImageBitmapFromUrl(url.Text);
                    if (imageBitmap == null) return;
                    image.SetImageBitmap(imageBitmap);

                    using (var client = new HttpClient())
                    {
                        var uri = $"{ServiceUrl}{url.Text}";
                        var result = await client.GetStringAsync(uri);
                        var resp = JsonConvert.DeserializeObject<ImageResponse>(result);

                        image.SetImageResource(resp.images.First().classifiers.Length > 0
                            ? Resource.Drawable.parentaladvisory
                            : Resource.Drawable.thumbsup);
                    }

                }
                else
                {
                    image.Visibility = ViewStates.Invisible;
                    image.SetImageResource(Resource.Drawable.Icon);
                }
            };
        }
    }
}