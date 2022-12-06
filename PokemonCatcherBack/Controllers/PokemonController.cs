using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MongoConnection;

namespace PokemonCatcherBack.Controllers
{
    public class PokemonController : ApiController
    {
        MongoConnection.MongoConnection Client = new MongoConnection.MongoConnection();


        public List<Pokemon> Get()
        {
            return Client.GetAllPokemon();
        }

        // POST api/<controller>
        public string Post([FromBody] Pokemon pokemon)
        {
            try
            {
                Client.InsertPokemon(pokemon);
            }
            catch (Exception)
            {
                return "Hubo un error guardando al pokemon.";
            }

            return "Pokemon guardado exitosamente.";
        }

        // PUT api/<controller>/5
        public Pokemon Put(string _id, string nickname)
        {
            Pokemon pokemon = new Pokemon();
            try
            {
                pokemon = Client.RenamePokemon(_id, nickname);
            }
            catch (Exception e)
            {

                throw e;
            }
            //return $"{nickname} was renamed.";  
            return pokemon;
        }

        // DELETE api/<controller>/5
        public string Delete(string _id)
        {
            try
            {
                Client.ReleasePokemon(MongoDB.Bson.ObjectId.Parse(_id));
            }
            catch (Exception e)
            {
                return $"Hubo un error liberar al pokemon: {e}";
            }

            return "Pokemon liberado exitosamente.";
        }
    }
}