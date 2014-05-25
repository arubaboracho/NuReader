using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace NuReader
{
    internal class NuAdapter : BaseAdapter<string>
    {
        private string[] _items;
        private Activity _context;

        public NuAdapter(Activity context, IEnumerable<string> items)
        {
            _items = items.ToArray();
            _context = context;
        }

        public override string this[int position]
        {
            get { return _items[position]; }
        }

        public override int Count
        {
            get { return _items.Length; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, Android.Views.View convertView, Android.Views.ViewGroup parent)

        {
            View view = convertView;
            if (view == null)
            {
                view = _context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            }

            view.FindViewById<TextView>(Android.Resource.Id.Text1).Text = _items[position];

            return view;
        }
    }
}