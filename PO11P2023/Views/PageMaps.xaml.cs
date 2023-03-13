using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Plugin.Geolocator;
using Xamarin.Forms.Maps;

namespace PO11P2023.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageMaps : ContentPage
    {
        public PageMaps()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var Conectividad = Connectivity.NetworkAccess;

            if(Conectividad == NetworkAccess.Internet)
            {
                var Localizacion = await Geolocation.GetLocationAsync();
                if(Localizacion != null) 
                { 
                    Pin ubicacion = new Pin();
                    ubicacion.Label = "Mi Ubicacion";
                    ubicacion.Address = "Mi Direccion";
                    ubicacion.Position = new Position(Localizacion.Latitude, Localizacion.Longitude);
                    mapa.Pins.Add(ubicacion);

                    mapa.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(Localizacion.Latitude, Localizacion.Longitude), Distance.FromKilometers(1)));

                }
            }
        }
    }
}