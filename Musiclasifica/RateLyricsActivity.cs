using System.Linq;
using System.Net.Http;
using System.Xml.Serialization;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace Musiclasifica
{
    [Activity(Label = "RateLyricsActivity")]
    public class RateLyricsActivity : Activity
    {
        const string ServiceUrl = "https://testlyrics.mybluemix.net/lyrics?lyrics=";
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.RateLyrics);

            var lyrics = FindViewById<EditText>(Resource.Id.txtLyrics);
            var image = FindViewById<ImageView>(Resource.Id.imgRate);
            var btnRateLyrics = FindViewById<Button>(Resource.Id.btnRateLyrics);

            image.Visibility = ViewStates.Invisible;

            btnRateLyrics.Click += async (s, e) =>
            {
                if (!string.IsNullOrWhiteSpace(lyrics.Text))
                {

                    var lyricsArray = lyrics.Text.Split('\n');
                    var lyricsInline = string.Join(" ", lyricsArray);

                    using (var client = new HttpClient())
                    {
                        var uri = $"{ServiceUrl}{lyricsInline}";
                        var result = await client.GetStringAsync(uri);

                        var response = JsonConvert.DeserializeObject<Musiclasifica.JsonResponse.ToneResponse>(result);

                        var anger = response.document_tone.tone_categories.First().tones.First().score;
                        var fear = response.document_tone.tone_categories.First().tones[2].score;
                        var sadness = response.document_tone.tone_categories.First().tones[4].score;

                        image.Visibility = ViewStates.Visible;
                        if (anger > 0.5 || fear > 0.5 || sadness > 0.5)
                        {
                            image.SetImageResource(Resource.Drawable.parentaladvisory);
                        }
                        else
                        {
                            image.SetImageResource(Resource.Drawable.thumbsup);
                        }
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