using MongoConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace PokemonCatcherBack.Controllers
{
    public class PokemonSourceController : ApiController
    {
        // GET api/<controller>
        public static async Task<HttpResponseMessage> Get()
        {
            var client = new HttpClient();
            Random random = new Random(DateTime.Now.Millisecond);
            var pokemon = await client.GetAsync($"https://pokeapi.co/api/v2/pokemon/{random.Next(1, 906)}");
            pokemon.Headers.Remove("Access-Control-Allow-Origin");
            return pokemon;
        }
    }

}