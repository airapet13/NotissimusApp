using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Widget;

namespace NotissimusApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait)]
    internal class OfferDetailsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.offer_details);

            string offerJson = Intent.GetStringExtra("OfferJson");

            TextView textViewOfferJson = FindViewById<TextView>(Resource.Id.textViewDetails);
            textViewOfferJson.Text = offerJson;
        }
    }
}