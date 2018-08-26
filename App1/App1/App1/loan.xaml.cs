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
    public partial class loan : ContentPage
    {
        static object locker = new object();
        public loan()
        {
            InitializeComponent();

            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "agripital.db3");
            var db = new SQLiteConnection(dpPath);
            var data2 = db.Query<cart>("SELECT * FROM cart").ToList<cart>();
            listview.ItemsSource = data2.ToList<cart>();

            money.Text = Convert.ToDouble(GetTotal()) + "";
        }
        public async void deletecart(object sender, ItemTappedEventArgs e)
        {
            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "agripital.db3"); //Call Database  
            var db = new SQLiteConnection(dpPath);
            var data = db.Table<cart>();

            var listview1 = e.Item as cart;

            var da = db.Query<cart>("DELETE FROM cart where product_name = '" + listview1.product_name + "'").FirstOrDefault();
            await DisplayAlert("Delete", "Menu Item is removed!", "Ok");

            var data2 = db.Query<cart>("SELECT * FROM cart").ToList<cart>();
            listview.ItemsSource = data2.ToList<cart>();

            money.Text = Convert.ToDouble(GetTotal()) + "";
        }
        public async void ord(object sender, EventArgs e)
        {
            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "agripital.db3");//Call Database  
            var db = new SQLiteConnection(dpPath);
            orders ord = new orders();
            var dat = db.Table<orders>();

            var data = db.Query<cart>("SELECT * FROM cart");

            if (data.Count > 0)
            {
                foreach (var val in data)
                {
                    ord.account_name = val.account_name;
                    ord.product_name = val.product_name;
                    ord.quantity = val.quantity;
                    ord.price = val.price;
                    ord.type = "Loan";
                    ord.percent = val.percent;
                    ord.subtotal = val.subtotal;
                    ord.dt = DateTime.Now;
                    db.Insert(ord);
                }
                money.Text = "0";
                await DisplayAlert("Yes", "Order successfully placed", "Ok");
            }
            var del = db.Query<cart>("DELETE FROM cart");
            var data2 = db.Query<cart>("SELECT * FROM cart").ToList<cart>();
            listview.ItemsSource = data2.ToList<cart>();
        }

        public int GetTotal()
        {
            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "agripital.db3");
            var db = new SQLiteConnection(dpPath);
            int gtot = 0;
            lock (locker)
            {
                List<cart> items = (from i in db.Table<cart>() select i).ToList();

                foreach (cart x in items)
                {
                    gtot += Convert.ToInt32(x.subtotal);
                }
            }
            return gtot;
        }
    }
}