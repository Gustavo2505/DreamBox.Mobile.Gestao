using DreamBox.Mobile.Domain.Models;
using DreamBox.Mobile.Gestao.Models;
using DreamBox.Mobile.Gestao.Services;
using DreamBox.Mobile.Gestao.Utility.Load;
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
    public partial class Register : ContentPage
    {

        private ItemService _service;
        Items items;
        public Register()
        {
            InitializeComponent();
            _service = new ItemService();
            items = new Items();


        }

        private async void BtnCadastrar(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            var price = txtPreco.Text;

            Items items = new Items() { nome = nome, preco = Convert.ToDouble(price) };



            await Navigation.PushPopupAsync(new Loading());
            ResponseService<Items> responseService = await _service.AddItems(items);
            if (responseService.isSucess)
            {

                await DisplayAlert("Sucesso", "Item inserido", "OK");
                await Navigation.PopAllPopupAsync();
                await Navigation.PopModalAsync();

            }
            else
            {
                await DisplayAlert("Erro", "Item nao inserido, consulte o adminsitrador do sistema", "OK");
            }
        }


    }
}