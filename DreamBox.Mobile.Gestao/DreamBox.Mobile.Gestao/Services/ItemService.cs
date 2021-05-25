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
    class ItemService : Service
    {

        public async Task<ResponseService<Items>> GetItem(int id)
        {
            HttpResponseMessage response = await _cliente.GetAsync($"{BaseApiUrl}/api/items/{id}");

            ResponseService<Items> responseService = new ResponseService<Items>();
            responseService.isSucess = response.IsSuccessStatusCode;
            responseService.statusCode = (int)response.StatusCode;

            if (response.IsSuccessStatusCode)
            {
                responseService.Data = await response.Content.ReadAsAsync<Items>();

            }
            else
            {
                var ProblemResponse = await response.Content.ReadAsStringAsync();
                var errors = JsonConvert.DeserializeObject<ResponseService<Items>>(ProblemResponse);
                responseService.Errors = errors.Errors;

            }
            return responseService;
        }

        public async Task<ResponseService<List<Items>>> GetallItems()
        {
            HttpResponseMessage response = await _cliente.GetAsync($"{BaseApiUrl}/api/Items");

            ResponseService<List<Items>> responseService = new ResponseService<List<Items>>();
            responseService.isSucess = response.IsSuccessStatusCode;
            responseService.statusCode = (int)response.StatusCode;

            if (response.IsSuccessStatusCode)
            {
                responseService.Data = await response.Content.ReadAsAsync<List<Items>>();

            }
            else
            {
                var ProblemResponse = await response.Content.ReadAsStringAsync();
                var errors = JsonConvert.DeserializeObject<ResponseService<List<Items>>>(ProblemResponse);
                responseService.Errors = errors.Errors;

            }
            return responseService;
        }






        public async Task<ResponseService<Items>> AddItems(Items items)
        {
            HttpResponseMessage response = await _cliente.PostAsJsonAsync($"{BaseApiUrl}/api/Items/", items);
            ResponseService<Items> responseService = new ResponseService<Items>();
            responseService.isSucess = response.IsSuccessStatusCode;
            responseService.statusCode = (int)response.StatusCode;




            if (response.IsSuccessStatusCode)
            {
                responseService.Data = await response.Content.ReadAsAsync<Items>();

            }
            else
            {
                //responseService.Errors = ;
            }
            return responseService;
        }

    }
}
