using DreamBox.Mobile.Domain.Models;
using DreamBox.Mobile.Gestao.Models;
using DreamBox.Mobile.Gestao.Services;
using DreamBox.Mobile.Gestao.Utility.Load;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DreamBox.Mobile.Gestao.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Sell : ContentPage
    {


        private ItemService _service;
        public ObservableCollection<Items> MainList { get; set; }
        public Sell()
        {
            InitializeComponent();

            _service = new ItemService();






            Navigation.PushPopupAsync(new Loading());
            PegaDado();
            Navigation.PopAllPopupAsync();
            BindingContext = this;
            // CVListaDeTarefas = PegaDado();
        }


        private void Abrir(object sender, EventArgs e)
        {
        }
        public async void PegaDado()
        {

            MainList = new ObservableCollection<Items>();
            var lst = await _service.GetallItems();
            // var lst = await _service.GetallItems();



            foreach (Items its in lst.Data)
            {
                MainList.Add(its);
            };

            //;

            /*if (responseService.isSucess)
            {
                _ListOfItems = new ObservableCollection<Items>(responseService.Data);
                CVListaDeTarefas.ItemsSource = responseService.Data;



            }*/
        }

        /*  public async void obs()
          {
          ResponseService<List<Items>> responseService = await _service.GetallItems();
          var listOfItemsService = responseService.Data;
              foreach (var item in listOfItemsService)
              {
                  _ListOfItems.Add(item);
              }
          //return item;
          }
        */
        private void BtnVoltar(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private async void BtnAdiciona(object sender, EventArgs e)
        {
         /*   string nome = txtNome.Text;
            string price = txtPreco.Text;

            Vendas vendas = new Vendas() { Nome = nome, preco = price };



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
            }*/
        }
    }
}
