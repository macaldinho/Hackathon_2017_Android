using Android.App;
using Android.OS;
using Android.Widget;

namespace Musiclasifica
{
    [Activity(Label = "Musiclasifica", MainLauncher = true, Icon = "@drawable/logo")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var btnRateCover = FindViewById<Button>(Resource.Id.btnCover);
            var btnRateLyrics = FindViewById<Button>(Resource.Id.btnLyrics);

            btnRateCover.Click += (s, e) =>
            {
                var intent = new Android.Content.Intent(this, typeof(RateCoverActivity));
                StartActivity(intent);
            };

            btnRateLyrics.Click += (s, e) =>
            {
                var intent = new Android.Content.Intent(this, typeof(RateLyricsActivity));
                StartActivity(intent);
            };
        }
    }
}

