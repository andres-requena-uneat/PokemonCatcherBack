﻿using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoConnection
{
    public class MongoConnection
    {
        private static MongoClient Client;
        private static IMongoDatabase Database;
        private static IMongoCollection<Pokemon> Collection;



        public MongoConnection()
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://mongoAtlasAdmin:veZQL13TQZ9aSweC@cluster0.5qfthto.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            Client = new MongoClient(settings);
            Database = Client.GetDatabase("pokecatcher");
            Collection = Database.GetCollection<Pokemon>("box");
        }

        public void InsertPokemon(Pokemon pokemon)
        {

            try
            {
                Collection.InsertOne(pokemon);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public List<Pokemon> GetBoxPage(int Page)
        {
            try
            {
                return PaginateBoxes(Page);

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public List<Pokemon> GetAllPokemon()
        {
            try
            {
                return Collection.Find(_ => true).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public void GetPokemon(Pokemon pokemon)
        {
            try
            {
                Collection.InsertOne(pokemon);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public Pokemon RenamePokemon(string id, string nickname)
        {
            Pokemon pokemon = new Pokemon();
            try
            {
                var update = Builders<Pokemon>.Update.Set("name", nickname);
                var filter = Builders<Pokemon>.Filter.Eq("_id", ObjectId.Parse(id));
                pokemon = Collection.FindOneAndUpdate(filter, update);
            }
            catch (Exception e)
            {
                throw e;
            }
            return pokemon;
        }

        public void ReleasePokemon(ObjectId id)
        {
            try
            {
                Collection.FindOneAndDelete(pokemon => (pokemon._id == id));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private List<Pokemon> PaginateBoxes(int Page)
        {
            var fullList = GetAllPokemon();
            var start = 30 * (Page - 1);
            var end = 30 * Page;
            var lastIndex = fullList.Count % 30;

            if (Page <= 0 || start > fullList.Count) return new List<Pokemon>();
            else if (Page > fullList.Count / 30) return fullList.GetRange(start, lastIndex);
            else return fullList.GetRange(start, 30);
        }
    }
}
