using Java.Text;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace practik
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsePage : ContentPage
    {
        int a = 90;
        public UsePage()
        {

            NavigationPage.SetHasBackButton(this, false);
            InitializeComponent();

            /*var contentView = Content as ContentView; // Получить ссылку на ContentView

            var swipeRightGesture = new SwipeGestureRecognizer { Direction = SwipeDirection.Right };
            swipeRightGesture.Swiped += OnSwipedRight;
            contentView.GestureRecognizers.Add(swipeRightGesture); // Использовать ссылку на contentView

            var swipeLeftGesture = new SwipeGestureRecognizer { Direction = SwipeDirection.Left };
            swipeLeftGesture.Swiped += OnSwipedLeft;
            contentView.GestureRecognizers.Add(swipeLeftGesture);*/
        }



        private async void OnSwipedRight(object sender, SwipedEventArgs e)
        {
            // Обработка свайпа вправо не нравится


            string Name;
            string Info;
            string Age;
            string photo;
            string zap;
            await DisplayAlert("Ошибка", "Неверный логин или пароль", "OK");
            string uri = $"http://butram.peabody28.com/profile/get-user-info?id={a}";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(uri);
            zap = await response.Content.ReadAsStringAsync();

            string input = zap;
            string[] values = input.Split(new string[] { "$$" }, StringSplitOptions.RemoveEmptyEntries);

            Name = values[0].Trim();
            Info = values[1].Trim();
            Age = values[2].Trim();
            photo = values[3].Trim();

            byte[] Ph = Convert.FromBase64String(photo);

            nameLabel.Text = $"Имя: {Name}";
            ageLabel.Text = $"Возраст: {Age}";
            infoLabel.Text = Info;
            photoImage.Source = ImageSource.FromStream(() => new MemoryStream(Ph));
            a++;
        }

        private async void OnSwipedLeft(object sender, SwipedEventArgs e)
        {
            // Обработка свайпа влево нравится
            string Name;
            string Info;
            string Age;
            string photo;
            string zap;
            await DisplayAlert("Ошибка", "Неверный логин или пароль", "OK");
            string uri = $"http://butram.peabody28.com/profile/get-user-info?id={a}";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(uri);
            zap = await response.Content.ReadAsStringAsync();

            string input = zap;
            string[] values = input.Split(new string[] { "$$" }, StringSplitOptions.RemoveEmptyEntries);

            Name = values[0].Trim();
            Info = values[1].Trim();
            Age = values[2].Trim();
            photo = values[3].Trim();

            byte[] Ph = Convert.FromBase64String(photo);

            nameLabel.Text = $"Имя: {Name}";
            ageLabel.Text = $"Возраст: {Age}";
            infoLabel.Text = Info;
            photoImage.Source = ImageSource.FromStream(() => new MemoryStream(Ph));
            a++;
        }
    }
}