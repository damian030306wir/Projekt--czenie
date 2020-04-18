using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Visitare
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RoutesPage : ContentPage
    {
        public RoutesPage()
        {
            InitializeComponent();
            GetRoutes();
        }
        private async void GetRoutes()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://dearjean.ddns.net:44301/api/Routes");
            var trasy = JsonConvert.DeserializeObject<List<Routes>>(response);
            routesList.ItemsSource = trasy;
        }
        private void OnTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}