using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace AndroidAppSummator
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private EditText editText1;
        private EditText editText2;
        private EditText editTextSum;
        private Button buttonCalcSum;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            this.editText1 = FindViewById<EditText>(Resource.Id.editText1);
            this.editText2 = FindViewById<EditText>(Resource.Id.editText2);
            this.editTextSum = FindViewById<EditText>(Resource.Id.editTextSum);
            this.buttonCalcSum = FindViewById<Button>(Resource.Id.buttonCalcSum);
            this.buttonCalcSum.Click += ButtonCalcSum_OnClick;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void ButtonCalcSum_OnClick(object sender, EventArgs eventArgs)
        {
            try
            {
                var number1 = decimal.Parse(this.editText1.Text);
                var number2 = decimal.Parse(this.editText2.Text);
                decimal sum = number1 + number2;
                this.editTextSum.Text = sum.ToString();
            } 
            catch (Exception)
            {
                this.editTextSum.Text = "error";
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}
