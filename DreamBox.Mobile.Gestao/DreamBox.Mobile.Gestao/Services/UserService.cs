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
    class UserService : Service
    {

        public async Task<ResponseService<Usuarios>> GetUSer(string email, string password)
        {
            HttpResponseMessage response = await _cliente.GetAsync($"{BaseApiUrl}/api/Users?email={email}&password={password}");

            ResponseService<Usuarios> responseService = new ResponseService<Usuarios>();
            responseService.isSucess = response.IsSuccessStatusCode;
            responseService.statusCode = (int)response.StatusCode;
            if (response.IsSuccessStatusCode)
            {
                responseService.Data = await response.Content.ReadAsAsync<Usuarios>();
            }
            else
            {
                string problemResponse = await response.Content.ReadAsStringAsync();
                var erros = JsonConvert.DeserializeObject<ResponseService<Usuarios>>(problemResponse);
                responseService.Errors = erros.Errors;
            }
            return responseService;
        }


        public async Task<Usuarios> addUser(Usuarios usuarios)
        {
            HttpResponseMessage response = await _cliente.PostAsJsonAsync($"{BaseApiUrl}/api/Users/", usuarios);

            if (response.IsSuccessStatusCode)
            {
                usuarios = await response.Content.ReadAsAsync<Usuarios>();

            }
            else
            {
                usuarios = null;
            }
            return usuarios;
        }


    }
}
