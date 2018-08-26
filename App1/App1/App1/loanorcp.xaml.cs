using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class loanorcp : ContentPage
	{
		public loanorcp ()
		{
			InitializeComponent ();
		}
        public async void tocart(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new carting());
        }
        public async void toloan(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new loan());
        }
	}
}