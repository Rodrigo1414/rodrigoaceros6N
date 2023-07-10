using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace rodrigoaceros6
{
    public partial class MainPage : ContentPage
    {
        private string Url = "https://192.168.1.102/uisraels5/ws_uisrael/post.php";
        private HttpClient cliente = new HttpClient();
        private ObservableCollection<Estudiante> post;


        public MainPage()
        {
            InitializeComponent();
            ObtenerDatos();
        }
        public async void ObtenerDatos()
        {
            var contenido = await cliente.GetStringAsync(Url);
            List<Estudiante> listPost = JsonConvert.DeserializeObject<List<Estudiante>>(contenido);
            post = new ObservableCollection<Estudiante>(listPost);
            ListaEstudiante.ItemsSource = post;
        }

        private void btnMostrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Insertar());

        }

        private void ListaEstudiante_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var objeto = (Estudiante)e.SelectedItem;
            var codigoTem = objeto.codigo.ToString();
            int codigo = Convert.ToInt32(codigoTem);
            string nombre = objeto.nombre.ToString();
            string apellido = objeto.apellido.ToString();
            var edadTem = objeto.codigo.ToString();
            int edad = Convert.ToInt32(edadTem);

            Navigation.PushAsync(new ActualizaEliminar(codigo, nombre, apellido, edad));

        }
    }
}
