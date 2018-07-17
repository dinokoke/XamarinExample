using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Network
{
    class MakeUpsData
    {
        public List<MakeUp> MakeUp { get; set; }

        
        public void AddOrUpdateRealm(Realm realm)
        {

            UpdateReferences(realm);
            //Asi se evita sobreescribir con objetos "vacíos" (solo con Id)
         //   RealmUtils.AddOrUpdateList(realm, this.MakeUp);

        }


        /**
         * Actualiza los objetos Realm a partir de sus IDs.
         */
        public void UpdateReferences(Realm realm)
        {
            foreach (MakeUp mup in MakeUp)
            {
               // mup.UpdateReferences(realm);
            }
        }

    }
}
