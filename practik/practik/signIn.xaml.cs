using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Android.Resource;

namespace practik
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class signIn : ContentPage
    {
        public signIn()
        {
            InitializeComponent();

            LoginButton.Clicked += LoginButtonClicked;
        }

        private async void LoginButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new signIn()));

            string Login = login.Text;
            string Pas = pas.Text;
            string Name = name.Text;

            HttpClient client = new HttpClient();

            // Создание строковых переменных для данных запроса
            string username = "butram";
            string email = "butram";
            string password = "butram";

            

            string uri = $"http://butram.peabody28.com/user/add-user?username=butram&email=butram&password=butram";
            HttpClient clients = new HttpClient();
            HttpResponseMessage response = clients.GetAsync(uri).Result;
            bool A = Convert.ToBoolean(await response.Content.ReadAsStringAsync());

            if (A) { 
                
            }



            //Navigation.PopAsync();

        }
    }
}