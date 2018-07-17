using Plugin.DeviceInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.Geolocator;
using System.Diagnostics;
using Plugin.Permissions.Abstractions;

using Refit;
using Plugin.Permissions;
using Realms;
using App3.Network;
using Plugin.Connectivity;

namespace App3
{
    public partial class MainPage : ContentPage
    {
        //Constructor de la clase. Contiene
        public int count;
        public MainPage()
        {
            InitializeComponent();

            Label1.Text = "Primer Label";
            var deviceId = CrossDeviceInfo.Current.Id;


            IdLabel.Text = "Mi Id es: " + deviceId;
            count = 0;
            //GetLocation();



            // Button1.Clicked += Button1_Clicked;

        }

        async Task GetUserName()
        {
            
            await SyncData();

            if (CheckConnection())
            {
                Device.StartTimer(TimeSpan.FromSeconds(5), update_data); //replace x with required seconds
            }
            else
            {
                await this.DisplayAlert("No existe conexión a internet", "Asegúrese de tener conexión a internet", "Ok");
            } 

        }

        public bool update_data()
        {
            SyncData();
            Debug.WriteLine("Valor Count: " + count);
            if (count == 5)
                return false;
            
            return true;
        }

        public async Task SyncData()
        {
            Debug.WriteLine("Sincrinozando..." + count);
            //descargar datos
            var nsAPI = RestService.For<IData>("http://makeup-api.herokuapp.com");
            var makeUpsData = await nsAPI.GetMakeUps("maybelline");

            Realm realm = Realm.GetInstance();
            foreach (var item in makeUpsData)
             {
                 realm.Write(() =>
                 {
                     realm.Add(item);
                 });
             }

            var totalObjects = realm.All<MakeUp>().Count();
            if (count < totalObjects)
            {
                var itemToShow = realm.All<MakeUp>().ElementAt(count);
                Label1.Text = itemToShow.Name;

                count += 1;
            }

        }

        protected async override void OnAppearing()
        {
            
            await GetUserName();
          /*    Realm realm = Realm.GetInstance();
            var item = realm.All<MakeUp>().ElementAt(1);
              Label1.Text = item.Name;*/

            GetLocation();
        }


        public async void GetLocation()
        {

            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
                Debug.WriteLine(status);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                    {
                        await DisplayAlert("Se necesita ubicación", "Se requiere ubicación para continuar", "OK");
                    }
                    var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Location });
                    status = results[Permission.Location];
                    Debug.WriteLine(status);
                    //  Debug.WriteLine("ESTOY EN LA PRIMERA");

                }
                if (status == PermissionStatus.Granted)
                {
                    //  Debug.WriteLine("ESTOY EN LA SEGUNDA");
                    var locator = CrossGeolocator.Current;

                    var cached = await locator.GetLastKnownLocationAsync();

                    var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(5));

                    LatitudeLabel.Text = "Latitud: " + position.Latitude;
                    LongitudeLabel.Text = "Longitude: " + position.Longitude;

                    locator.PositionChanged += (sender, e) =>
                    {
                        var userPosition = e.Position;
                        LatitudeLabel.Text = "Latitud: " + userPosition.Latitude;
                        LongitudeLabel.Text = "Longitude: " + userPosition.Longitude;


                    };
                }
                else if (status != PermissionStatus.Unknown)
                {
                    await DisplayAlert("Location Denied", "Can not continue, try again.", "OK");
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

        }

        public bool CheckConnection()
        {

            if (CrossConnectivity.Current.IsConnected)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Button1_Clicked(object sender, EventArgs e)
        {

        }
    }
}
