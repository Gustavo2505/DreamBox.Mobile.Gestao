using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace DreamBox.Mobile.Gestao.Services
{
    public abstract class Service
    {

        protected string BaseApiUrl = "https://ljgestao.azurewebsites.net";
        protected HttpClient _cliente;

        public Service()
        {
            _cliente = new HttpClient();
        }
    }
}
