using DreamBox.Mobile.Domain.Models;
using DreamBox.Mobile.Gestao.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DreamBox.Mobile.Gestao.Services
{
    class VendaService : Service
    {

        public async Task<ResponseService<Vendas>> GetVendas(int id)
        {
            HttpResponseMessage response = await _cliente.GetAsync($"{BaseApiUrl}/api/Vendas/{id}");

            ResponseService<Vendas> responseService = new ResponseService<Vendas>();
            responseService.isSucess = response.IsSuccessStatusCode;
            responseService.statusCode = (int)response.StatusCode;

            if (response.IsSuccessStatusCode)
            {
                responseService.Data = await response.Content.ReadAsAsync<Vendas>();

            }
            else
            {
                var ProblemResponse = await response.Content.ReadAsStringAsync();
                var errors = JsonConvert.DeserializeObject<ResponseService<Vendas>>(ProblemResponse);
                responseService.Errors = errors.Errors;

            }
            return responseService;
        }

        public async Task<ResponseService<List<Vendas>>> GetAllVendas()
        {
            HttpResponseMessage response = await _cliente.GetAsync($"{BaseApiUrl}/api/Vendas");

            ResponseService<List<Vendas>> responseService = new ResponseService<List<Vendas>>();
            responseService.isSucess = response.IsSuccessStatusCode;
            responseService.statusCode = (int)response.StatusCode;

            if (response.IsSuccessStatusCode)
            {
                responseService.Data = await response.Content.ReadAsAsync<List<Vendas>>();

            }
            else
            {
                var ProblemResponse = await response.Content.ReadAsStringAsync();
                var errors = JsonConvert.DeserializeObject<ResponseService<List<Vendas>>>(ProblemResponse);
                responseService.Errors = errors.Errors;

            }
            return responseService;
        }






        public async Task<ResponseService<Vendas>> AddVenda(Vendas vendas)
        {
            HttpResponseMessage response = await _cliente.PostAsJsonAsync($"{BaseApiUrl}/api/Items/", vendas);
            ResponseService<Vendas> responseService = new ResponseService<Vendas>();
            responseService.isSucess = response.IsSuccessStatusCode;
            responseService.statusCode = (int)response.StatusCode;




            if (response.IsSuccessStatusCode)
            {
                responseService.Data = await response.Content.ReadAsAsync<Vendas>();

            }
            else
            {
                //responseService.Errors = ;
            }
            return responseService;
        }

    }
}
