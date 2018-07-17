using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App3;
using App3.iOS;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ColorLabel), typeof(ColorLabelRenderer))]
namespace App3.iOS
{
    class ColorLabelRenderer : LabelRenderer
    {

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
                Control.TextColor = UIColor.Brown;
            }
        }

    }
}