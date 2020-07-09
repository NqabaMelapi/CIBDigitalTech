using System;
using NUnit.Framework;
using System.Threading.Tasks;
using Core.CIBDigitalTech.API;
using Core.CIBDigitalTech.API.Utilities;

namespace Test.CIBDigitalTech.API
{
    public class DogBreedAPI
    {

        [Test]
        public void GetAllDogBreeds()
        {

            var results = Task.Run(async () => await Method.Get("https://dog.ceo/api/breeds/list/all") ).Result;
            
            Assert.IsTrue(!String.IsNullOrEmpty(results), "no results returned");
            JsonUtil.GetChildNode(results, "message", "retriever");

            Assert.IsTrue(JsonUtil.CheckChildNode(results, "message", "retriever"), "Sub breed retriever is not on the list");
        }

        [Test]
        public void GetRetrieverSubBreeds()
        {

            var results = Task.Run(async () => await Method.Get("https://dog.ceo/api/breed/retriever/list")).Result;
            Assert.True(!String.IsNullOrEmpty(results), "Sub breed retriever not found");
        }

        [Test]
        public void GetGoldenSubBreedRandomImage()
        {
            var results = Task.Run(async () => await Method.Get("https://dog.ceo/api/breed/golden/images/random")).Result;
            Assert.True(!String.IsNullOrEmpty(results), "Sub breed golden image not found");
        }


    }
}
