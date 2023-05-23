using practik;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Net;
using System.Net.Http;
using Newtonsoft;
using Newtonsoft.Json;



namespace practik
{

    

    public partial class MainPage : ContentPage
    {

        //DB Me = new DB("db4free.net", 3306, "testdbqwe", "testdbqwetestdbqwe", "matchmaker");


        public MainPage()
        {
            InitializeComponent();

            LoginButton.Clicked += LoginButtonClicked;

            SigninButton.Clicked += SigninButtonClicked;
        }


        private async void LoginButtonClicked(object sender, EventArgs e)
        {

            var profiles = Connectivity.ConnectionProfiles;
            while (!profiles.Contains(ConnectionProfile.WiFi))
            {
                await DisplayAlert("Ошибка", "Отсутвует интернет подключение, подключитесь к интернету и перезапустите приложение", "OK");
            }

            string UserParol = parol.Text;
            string UserLogin = login.Text;

            if (UserLogin == "" || UserLogin == "") {
                await DisplayAlert("Ошибка", "Поля не могут быть пустыми", "OK");
            }

            // zapros
            string uri = $"http://butram.peabody28.com/user/get-user-id?username={Uri.EscapeDataString(UserLogin)}";
            HttpClient client = new HttpClient();
            HttpResponseMessage response =  client.GetAsync(uri).Result;
            int ID = Convert.ToInt32(await response.Content.ReadAsStringAsync());
            //zapros
            if (ID == 0) {
                await DisplayAlert("Ошибка", "Неверный логин или пароль", "OK");
                return;
            }

            string uri1 = $"http://butram.peabody28.com/user/check-user-pass?pas={Uri.EscapeDataString(UserParol)}&id={ID}";
            HttpClient A = new HttpClient();
            HttpResponseMessage responses = await A.GetAsync(uri1);
            bool findedUser = Convert.ToBoolean(await responses.Content.ReadAsStringAsync());

            if (findedUser)
            {
                Person person = new Person();
                person.Id = ID;
                await Navigation.PushAsync(new NavigationPage(new UsePage()));
            }
            else {
                await DisplayAlert("Ошибка", "Неверный логин или пароль", "OK");
            }


        }

        private async void SigninButtonClicked(object sender, EventArgs e)
        {
            await DisplayAlert("", "влево - нравится, впрово - не нравится", "OK");
            await Navigation.PushAsync(new NavigationPage(new signIn()));
            //Navigation.PopAsync();
        }
    }
}

