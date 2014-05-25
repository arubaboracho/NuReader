using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using RSSlib;

namespace NuReader
{
    [Activity(Label = "NuReader", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            //button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };

            button.Click += button_Click;

        }

        void button_Click(object sender, EventArgs e)
        {

            ThreadPool.QueueUserWorkItem(delegate(object state)
            {
                
                var items = NuRSS.GetItems();
                ListView listView1 = FindViewById<ListView>(Resource.Id.listView1);
                NuAdapter adapter = new NuAdapter(this, items);
               

                RunOnUiThread(() =>
                {
                    listView1.Adapter = adapter;
                });
            }
                , null);

        }
    }
}

