using DreamBox.Mobile.Domain.Models;
using DreamBox.Mobile.Gestao.Models;
using DreamBox.Mobile.Gestao.Services;
using DreamBox.Mobile.Gestao.Utility.Load;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Extensions;
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
    public partial class Login : ContentPage
    {
        private UserService _service;
        Usuarios user;
        public Login()
        {



            InitializeComponent();
            _service = new UserService();
            user = new Usuarios();

        }

        private async void BtnLogin(object sender, EventArgs e)
        {

            string email = Txtemail.Text;
            string password = Txtpassword.Text;


            await Navigation.PushPopupAsync(new Loading());
            ResponseService<Usuarios> responseService = await _service.GetUSer(email, password);
            if (responseService.isSucess)
            {
                App.Current.Properties.Add("User", JsonConvert.SerializeObject(responseService.Data));
                await App.Current.SavePropertiesAsync();
                await Navigation.PopAllPopupAsync();
                await Navigation.PushAsync(new Menu());
                Navigation.RemovePage(this);
            }
            else
            {

                //verificar como desativa o recurso nativo do android de "voltar" pois esta dando problema com meu mecanismo de persistencia     


                await DisplayAlert("Atenção", "usuário nao encontrado, contate o adminsitrador do sistema", "ok");
                await Navigation.PopAllPopupAsync();


            }


        }


    }
}