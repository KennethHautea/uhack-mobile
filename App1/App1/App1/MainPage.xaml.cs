using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SQLite;
using System.IO;

namespace App1
{
	public partial class MainPage : ContentPage
	{
		public MainPage(string user)
		{
			InitializeComponent();
            CreateDB();
            username.Text = user;

            if(username.Text != null)
            {
                logbtn.IsVisible = false;
                outbtn.IsVisible = true;
                viewbtn.IsVisible = true;
            }
		}
        public string CreateDB()
        {
            var output = "";
            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "agripital.db3"); //Create New Database  
            var db = new SQLiteConnection(dpPath);
            db.CreateTable<accounts>();
            db.CreateTable<products>();
            db.CreateTable<cart>();
            db.CreateTable<orders>();
            return output;
        }
        public async void regAccount(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterAccount());
        }
        public async void logAccount(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Login());
        }
        public async void tofert(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new fert(username.Text));
        }
        public async void toseed(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new seed(username.Text));
        }
        public async void topest(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new pest(username.Text));
        }
        public async void toherbi(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new herbi(username.Text));
        }
        public async void toinsect(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new insect(username.Text));
        }

        public async void tocart(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new loanorcp());
        }
        public async void vieword(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new View(username.Text));
        }
        public async void logOut(object sender, EventArgs e)
        {
            await DisplayAlert("Logging out", username.Text + " Logged out", "Ok");
            username.Text = "";
            logbtn.IsVisible = true;
            outbtn.IsVisible = false;
            viewbtn.IsVisible = false;
        }
    }
}
