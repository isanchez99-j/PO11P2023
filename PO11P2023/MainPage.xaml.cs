using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PO11P2023;

namespace PO11P2023
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnsegunda_Clicked(object sender, EventArgs e)
        {
            var estudiante = new Models.Estudiante
            {
                nombres = nombre.Text,
                apellidos = apellido.Text,
                telefono = telefono.Text
            };

            var pagina = new Views.PageTwo();
            pagina.BindingContext = estudiante;
            await Navigation.PushAsync(pagina);

        }
    }
}
