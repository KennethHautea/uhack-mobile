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
	public partial class fert : ContentPage
	{
		public fert (string user)
		{
			InitializeComponent ();
            username.Text = user;

            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "agripital.db3");
            var db = new SQLiteConnection(dpPath);

            var data1 = db.Query<products>("SELECT * FROM products where type == 'Fertilizer'").ToList<products>();

            listview.ItemsSource = data1.ToList<products>();
        }
        public async void tapped(object sender, ItemTappedEventArgs e)
        {
            var listview = e.Item as products;

            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "agripital.db3"); //Call Database  
            var db = new SQLiteConnection(dpPath);
            cart tbl = new cart();


            var dat = db.Table<cart>();
            var da = dat.Where(x => x.product_name == listview.product_name).FirstOrDefault();

            if (da != null)
            {
                da.product_name = da.product_name;
                da.quantity = da.quantity + 1;
                da.percent = da.percent;
                da.price = listview.price * da.quantity;

                double sub = da.percent * da.price;

                da.subtotal = sub + da.price;

                db.Update(da);
                await DisplayAlert("Duplicate Product", "Product added to cart", "Ok");
            }
            else
            {
                tbl.account_name = username.Text;
                tbl.product_name = listview.product_name;
                tbl.quantity = 1;
                tbl.percent = 0.05;
                tbl.price = listview.price;

                double sub = tbl.percent * tbl.price;

                tbl.subtotal = tbl.price + sub;

                db.Insert(tbl);
                await DisplayAlert("Order Product", "Product added to cart", "Ok");
            }
        }
	}
}