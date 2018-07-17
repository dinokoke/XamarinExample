using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App3
{
    public class EntryKeyEffect : RoutingEffect
    {

        public string KeyBoardText { get; set; }

        public EntryKeyEffect() : base("Keys.EntryKeyEffect")
        {

        }

    }
}
