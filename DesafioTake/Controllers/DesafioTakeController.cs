using DesafioTake.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace DesafioTake.Controllers
{
    [ApiController]
    [Route("api")]
    public class DesafioTakeController : ControllerBase
    { 

        [HttpGet("BuscaRepositoriosAntigos")]
        public async Task<List<Repositorio>> BuscaRepositoriosAntigos()
         {
            var client = new RestClient("https://api.github.com/users/takenet/repos");
            var request = new RestRequest();
            RestResponse response = client.Execute(request);
            var listaRepositorios = JsonConvert.DeserializeObject<List<Repositorio>>(response.Content);

            var repositoriosCsharp = new List<Repositorio>();
            listaRepositorios.ForEach(r =>
            {
                if (r.Language == "C#")
                    repositoriosCsharp.Add(r);
            });
           var maisAtingos = repositoriosCsharp.OrderBy(x => x.Created_At)
                              .Take(5);
            return maisAtingos.ToList();

        }
    }
}
