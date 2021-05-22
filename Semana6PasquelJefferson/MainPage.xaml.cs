using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Semana6PasquelJefferson
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://192.168.10.2/moviles/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Semana6PasquelJefferson.Datos> _post;
        public MainPage()
        {
            InitializeComponent();
            get();
        }

        public async void get()
        {
            try
            {
                var content = await client.GetStringAsync(Url);
                List<Semana6PasquelJefferson.Datos> posts = JsonConvert.DeserializeObject<List<Semana6PasquelJefferson.Datos>>(content);
                _post = new ObservableCollection<Semana6PasquelJefferson.Datos>(posts);
                MyListView.ItemsSource = _post;

            }
            catch (Exception ex)
            {
                await DisplayAlert("error", "error" + ex.Message, "ok");

            }

        }

        private async void btnGet_Clicked(object sender, EventArgs e)

        {
            await Navigation.PushModalAsync(new InsertarPost());

            //var content = await client.GetStringAsync(Url);
            // List<SEMANA6_ANAGUMBLA_GABRIEL.Datos> posts = JsonConvert.DeserializeObject<List<SEMANA6_ANAGUMBLA_GABRIEL.Datos>>(content);
            //  _post = new ObservableCollection<SEMANA6_ANAGUMBLA_GABRIEL.Datos>(posts);

            //  MyListView.ItemsSource = _post;
        }


        private async void btnPost_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Put());

        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Eliminar());


        }



    }
}
