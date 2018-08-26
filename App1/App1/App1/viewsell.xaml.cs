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
	public partial class viewsell : ContentPage
	{
		public viewsell ()
		{
			InitializeComponent ();

            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "agripital.db3");
            var db = new SQLiteConnection(dpPath);

            var data1 = db.Query<orders>("SELECT * FROM orders").ToList<orders>();

            listview.ItemsSource = data1.ToList<orders>();
        }
	}
}