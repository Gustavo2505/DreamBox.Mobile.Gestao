using DreamBox.Mobile.Gestao.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Menu = DreamBox.Mobile.Gestao.Views.Menu;

namespace DreamBox.Mobile.Gestao
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //TODO: CRIAR CHECKBOX PARA VERIFICAR SE USUÁRIO DESEJA MANTER-SE LOGADO.
            App.Current.Properties.Remove("User");
            if (App.Current.Properties.ContainsKey("User"))
            {
                MainPage = new NavigationPage(new Menu());
            }
            else
            {

                MainPage = new NavigationPage(new Login());
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
