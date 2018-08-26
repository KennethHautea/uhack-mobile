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
	public partial class RegisterAccount : ContentPage
	{
		public RegisterAccount ()
		{
			InitializeComponent ();

            typepicker.Items.Add("Customer");
            typepicker.Items.Add("Seller");
        }
        public async void register(object sender, EventArgs e)
        {
            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "agripital.db3");

            var db = new SQLiteConnection(dpPath);
            accounts acnt = new accounts();
            var dat = db.Table<accounts>();

            var da = dat.Where(x => x.username == username.Text).FirstOrDefault();

            if(da != null)
            {
                await DisplayAlert("Error", "Username is already taken", "Ok");
            }
            else
            {
                var ty = typepicker.Items[typepicker.SelectedIndex];
                int con = Convert.ToInt32(contact.Text);

                acnt.username = username.Text;
                acnt.password = password.Text;
                acnt.name = name.Text;
                acnt.address = address.Text;
                acnt.contact = con;
                acnt.type = ty;
                db.Insert(acnt);

                await DisplayAlert("Success", "Account successfully created", "Ok");
            }
        }
	}
}