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
	public partial class View : ContentPage
	{
		public View (string user)
		{
			InitializeComponent ();
            username.Text = user;

            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "agripital.db3");
            var db = new SQLiteConnection(dpPath);

            var data1 = db.Query<orders>("SELECT * FROM orders where account_name == '" +username.Text+ "'").ToList<orders>();

            listview.ItemsSource = data1.ToList<orders>();
        }
	}
}