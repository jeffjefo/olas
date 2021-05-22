using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Semana6PasquelJefferson
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Eliminar : ContentPage
    {
        public Eliminar()
        {
            InitializeComponent();
        }
        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txtCodigo.Text);

            //delete por id 
            HttpClient client = new HttpClient();
            var resultado = await client.DeleteAsync(String.Concat("http://192.168.10.2/moviles/post.php", txtCodigo.Text));
            if (resultado.IsSuccessStatusCode)
            {
                await DisplayAlert("Exitoooo", "Registro eliminado", "Ok");
            }
        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MainPage());

        }
    }
}