using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace PO11P2023
{
    public partial class App : Application
    {
        static Controllers.DBEquipos dbequipos;

        public static Controllers.DBEquipos Dbequipos
        {
            get
            {
                if (dbequipos == null)
                {
                    var pathApp = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    var DBName = Models.Configuraciones.DBname ;
                    var PathFull = Path.Combine(pathApp, DBName);


                    dbequipos = new Controllers.DBEquipos(PathFull);
                }
                return dbequipos;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage (new Views.PagePrincipal());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
