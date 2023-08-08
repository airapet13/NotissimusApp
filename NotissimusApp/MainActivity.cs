using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using AndroidX.AppCompat.App;
using AndroidX.RecyclerView.Widget;
using Newtonsoft.Json;
using NotissimusApp.Services;
using System.Collections.Generic;


namespace NotissimusApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : AppCompatActivity
    {
        private RecyclerView _recyclerView;
        private OfferAdapter _adapter;
        private List<Offer> _offersList;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            _recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            LinearLayoutManager layoutManager = new LinearLayoutManager(this);
            _recyclerView.SetLayoutManager(layoutManager);

            _adapter = new OfferAdapter(new List<Offer>());

            _adapter.ItemClick += (sender, offer) =>
            {
                Intent intent = new Intent(this, typeof(OfferDetailsActivity));
                intent.PutExtra("OfferJson", JsonConvert.SerializeObject(offer, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                }));
                StartActivity(intent);
            };

            _recyclerView.SetAdapter(_adapter);

            Load();
        }

        private async void Load()
        {
            ProgressDialog progressDialog = new ProgressDialog(this);
            progressDialog.SetMessage("Идёт загрузка данных...");
            progressDialog.SetCancelable(false);
            progressDialog.Show();

            HttpService httpService = new HttpService();
            string url = "https://partner.market.yandex.ru/pages/help/YML.xml";
            string xmlData = await httpService.GetData(url);

            XmlService xmlParser = new XmlService();
            _offersList = xmlParser.ParseXmlData(xmlData);

            _adapter.UpdateData(_offersList);

            progressDialog.Dismiss();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}