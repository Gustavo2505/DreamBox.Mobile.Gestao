using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DreamBox.Mobile.Gestao.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : ContentPage
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void BtnSell(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Sell());
        }

        private void BtnMoney(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Money());
        }

        private void BtnRegister(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Register());
        }

        private void BtnLogout(object sender, EventArgs e)
        {
            App.Current.Properties.Remove("User");
            Navigation.PushAsync(new Login());
            Navigation.RemovePage(this);

        }
    }
}