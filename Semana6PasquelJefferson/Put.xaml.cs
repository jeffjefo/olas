using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Semana6PasquelJefferson
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Put : ContentPage
    {
        public Put()
        {
            InitializeComponent();
        }
        private void btnModificar_Clicked(object sender, EventArgs e)
        {

            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();

                parametros.Add("codigo", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);
                cliente.UploadValues("http://192.168.10.2/moviles/post.php", "PUT", parametros);



                //await DisplayAlert("Alerta", "ingresado correctamente", "ok");
                var mensaje = "Dato Actualizado con exito";
                DependencyService.Get<Mensaje>().LongAlert(mensaje);
                txtCodigo.Text = "";
                txtNombre.Text = "";
                txtApellido.Text = "";
                txtEdad.Text = "";
            }
            catch (Exception ex)
            {

               //await DisplayAlert("error", ex.Message, "ok");
                DependencyService.Get<Mensaje>().ShortAlert(ex.Message);

            }
        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MainPage());

        }
    }
}