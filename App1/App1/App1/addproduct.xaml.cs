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
	public partial class addproduct : ContentPage
	{
		public addproduct ()
		{
			InitializeComponent ();
            typepicker.Items.Add("Fertilizer");
            typepicker.Items.Add("Insecticide");
            typepicker.Items.Add("Herbicide");
            typepicker.Items.Add("Pesticide");
            typepicker.Items.Add("Seedlings");
        }
        public async void productadd(object sender, EventArgs e)
        {
            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "agripital.db3");

            var db = new SQLiteConnection(dpPath);
            products prod = new products();
            var dat = db.Table<products>();

            double pr = Convert.ToDouble(price.Text);

            var ty = typepicker.Items[typepicker.SelectedIndex];

            prod.product_name = productname.Text;
            prod.type = ty;
            prod.price = pr;
            prod.description = description.Text;
            db.Insert(prod);
            await DisplayAlert("Success", "Item added successfully", "Ok");
        }
	}
}