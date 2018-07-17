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
using App3;
using App3.Droid;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(ColorLabel), typeof(ColorLabelRenderer))]
namespace App3.Droid
{
    using Android.Graphics.Drawables;
    using Xamarin.Forms.Platform.Android;
    using Label = Label;

    class ColorLabelRenderer : LabelRenderer
    {
        public ColorLabelRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {

            }
            else if (e.OldElement != null)
            {

            }

            if (Control != null)
            {
                Control.SetTextColor(Android.Graphics.Color.DarkGreen);
            }
        }
    }
}