using Realms;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace App3.Network
{
    class SyncManager
    {

        /**
         * Descarga los datos del servidor, los guarda en realm 
         * y actualiza la fecha de sincronización.
         * 
         * Retorna true en caso de exito.
         */
       /* public static async Task<Boolean> SyncBasic()
        {
            Realm realm = Realm.GetInstance();
            Console.WriteLine("Database path: " + realm.Config.DatabasePath);

            //descargar datos
            var nsAPI = RestService.For<IData>("http://makeup-api.herokuapp.com");
            var makeUpsData = await nsAPI.GetMakeUps("maybelline");


            //actualizar realm
            bool success;
            try
            {
                realm.Write(() =>
                {
                   // makeUpsData.AddOrUpdateRealm(realm);
                });
                success = true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                success = false;
            }


            //return
            if (success)
            {
                Settings.LastSyncDate = DateTime.Now;
                Console.WriteLine("Sync successful");
                return true;
            }
            else
            {
                Console.WriteLine("Sync failed");
                return false;
            }

        }*/

        /**
         * Verifica la fecha de última sincronización, solo actualiza tras haber pasado "X" días.
         * La cantidad de dias esta definida en Constants.DaysBetweenSyncs.
         * 
         * El método recibe una página como parámetro opcional. 
         * Si es diferente de null, se ejecuta SyncInterface, sino SyncBasic.
         */
       /* public static async Task SyncPeriodically(Page page = null)
        {

            if ((DateTime.Now - Settings.LastSyncDate).TotalDays > Constants.DaysBetweenSyncs)
            {
                await SyncBasic();
               /* if (page != null)
                {
                    await SyncInterface(page);
                }
                else
                {
                    await SyncBasic();
                }*/
         /*   }
            else
            {
                Console.WriteLine("Sync skipped. The last sync was the " + Settings.LastSyncDate);
            }
        }*/

    }
}
