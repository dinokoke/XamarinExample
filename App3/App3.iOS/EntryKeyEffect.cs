using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("Keys")]
[assembly: ExportEffect(typeof(App3.EntryKeyEffect), "EntryKeyEffect")]
namespace App3.iOS
{
    class EntryKeyEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                var effect = (App3.EntryKeyEffect)Element.Effects.FirstOrDefault(e => e is App3.EntryKeyEffect);
                if (effect != null)
                {
                    if (effect.KeyBoardText == "Listo")
                    {
                        (Control as UITextField).ReturnKeyType = UIReturnKeyType.Done;
                    }
                    if (effect.KeyBoardText == "Siguiente")
                    {
                        (Control as UITextField).ReturnKeyType = UIReturnKeyType.Next;
                    }
                }

            }
            catch
            {

            }
        }

        protected override void OnDetached()
        {
            throw new NotImplementedException();
        }
    }
}