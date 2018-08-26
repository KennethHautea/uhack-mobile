using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.IO;

namespace App1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
		public Login ()
		{
			InitializeComponent ();
		}
        public async void log(object sender, EventArgs e)
        {
            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "agripital.db3");

            var db = new SQLiteConnection(dpPath);
            accounts acnt = new accounts();
            var dat = db.Table<accounts>();

            var da = dat.Where(x => x.username == username.Text && x.password == password.Text).FirstOrDefault();

            if(da != null)
            {
                await DisplayAlert("Success", "Login Successful", "Ok");

                var da1 = dat.Where(x => x.type == "Seller" && x.username == username.Text).FirstOrDefault();
                if (da1 != null)
                {
                    await Navigation.PushAsync(new vieworadd());
                }
                else
                { 
                    await Navigation.PushAsync(new MainPage(username.Text));
                }
            }
            else
            {
                await DisplayAlert("Error", "Login Failed", "Ok");
            }
        }
	}
}